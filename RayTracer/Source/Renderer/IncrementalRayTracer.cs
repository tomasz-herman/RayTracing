using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using RayTracing.Cameras;
using RayTracing.Materials;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.Sampling;
using RayTracing.Shaders;
using RayTracing.World;

namespace RayTracing
{
    public class IncrementalRayTracer : RayTracer, IRenderer
    {
        public bool RecursionRenderPart { get; set; } = true;
        public int SamplesRenderStep { get; set; } = 50;
        public int SamplesInRecursion { get; set; } = 50;

        public Action<int, List<object>> OnFrameReady { get; set; }
        public Func<bool> IsCancellationRequested { get; set; }

        public void Render(Scene scene, Camera camera)
        {
            scene.Preprocess();
            int width = Resolution;
            int height = (int) (width / camera.AspectRatio);
            var image = new Texture(width, height);
            AbstractSampler<Vector2> sampler = new ThreadSafeSampler<Vector2>(Sampling, Samples);

            if (RecursionRenderPart)
            {
                RecursionPart(width, height, sampler, camera, scene, image);
                image.Process(_ => new Color());
            }
            if (IsCancellationRequested != null && IsCancellationRequested())
                return;
            SamplesPart(width, height, sampler, camera, scene, image);
        }

        public IncrementalRayTracer(int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution) :
            base(maxDepth, samples, sampling, resolution)
        {
        }

        private void RecursionPart(int width, int height, AbstractSampler<Vector2> sampler, Camera camera, Scene scene,
            Texture image)
        {
            for (int recDepth = 1; recDepth < MaxDepth; recDepth++)
            {
                image.Process(_ => new Color());
                for (int k = 0; k < SamplesInRecursion; k++)
                {
                    Parallel.For(0, width, i =>
                    {
                        if (IsCancellationRequested != null && IsCancellationRequested())
                            return;
                        for (int j = 0; j < height; j++)
                        {
                            var sample = sampler.GetSample(k);
                            float u = (i + sample.X) / (width - 1);
                            float v = (j + sample.Y) / (height - 1);
                            Ray ray = camera.GetRay(u, v);
                            image[i, j] += Shade(ray, scene, recDepth);
                        }
                    });
                    if (IsCancellationRequested != null && IsCancellationRequested())
                        return;
                }

                var output = new Texture(image);
                output.Process(c => (c / SamplesInRecursion).Clamp());
                output.AutoGammaCorrect();
                var percentage = recDepth * 100 / MaxDepth;
                OnFrameReady?.Invoke(percentage,
                    new List<object> {output, $"Recursion level: {percentage}%, {recDepth}/{MaxDepth}"});
            }
        }

        private void SamplesPart(int width, int height, AbstractSampler<Vector2> sampler, Camera camera, Scene scene,
            Texture image)
        {
            for (int k = RecursionRenderPart ? SamplesInRecursion : 0; k < Samples; k++)
            {
                Parallel.For(0, width, i =>
                {
                    if (IsCancellationRequested != null && IsCancellationRequested())
                        return;
                    for (int j = 0; j < height; j++)
                    {
                        var sample = sampler.GetSample(k);
                        float u = (i + sample.X) / (width - 1);
                        float v = (j + sample.Y) / (height - 1);
                        Ray ray = camera.GetRay(u, v);
                        image[i, j] += Shade(ray, scene, MaxDepth);
                    }
                });
                if (IsCancellationRequested != null && IsCancellationRequested())
                    return;

                if (k % SamplesRenderStep == 0 || k == Samples - 1)
                {
                    var output = new Texture(image);
                    output.Process(c => (c / (k + 1)).Clamp());
                    output.AutoGammaCorrect();
                    var percentage = (k + 1) * 100 / Samples;
                    OnFrameReady?.Invoke(percentage,
                        new List<object> {output, $"Samples percentage: {percentage}%, {k}/{Samples}"});
                }
            }
        }
    }
}