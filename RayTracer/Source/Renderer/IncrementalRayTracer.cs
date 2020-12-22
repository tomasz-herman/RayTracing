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
        public Action<int, Texture> OnFrameReady { get; set; }
        public Func<bool> IsCancellationRequested { get; set; }

        public IncrementalRayTracer(int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution) :
            base(maxDepth, samples, sampling, resolution)
        {
        }

        public void Render(Scene scene, Camera camera)
        {
            scene.Preprocess();
            int width = Resolution;
            int height = (int) (width / camera.AspectRatio);
            var image = new Texture(width, height);
            AbstractSampler<Vector2> sampler = new ThreadSafeSampler<Vector2>(Sampling, Samples);

            for (int k = 0; k < Samples; k++)
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
                        image[i, height - 1 - j] += Shade(ray, scene, MaxDepth);
                    }
                });
                if (IsCancellationRequested != null && IsCancellationRequested())
                    return;

                var output = new Texture(image);
                output.Process(c => (c / (k + 1)).Clamp().GammaCorrection(2.0f));
                OnFrameReady?.Invoke((k + 1) * 100 / Samples, output);
            }
        }
    }
}