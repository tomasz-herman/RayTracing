using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenTK;
using RayTracing.Cameras;
using RayTracing.Materials;
using RayTracing.Maths;
using RayTracing.Sampling;
using RayTracing.World;

namespace RayTracing
{
    public class SamplesRayTracer : IncrementalRayTracer
    {
        private readonly int _samplesRenderStep;
        
        public SamplesRayTracer(int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution, int samplesRenderStep) : base(
            maxDepth, samples, sampling, resolution)
        {
            _samplesRenderStep = samplesRenderStep;
        }

        public override void Render(Scene scene, Camera camera)
        {
            scene.Preprocess();
            int width = Resolution;
            int height = (int) (width / camera.AspectRatio);
            var image = new Texture(width, height);
            AbstractSampler<Vector2> sampler = new ThreadSafeSampler<Vector2>(Sampling, Samples);

            for (int k = 0; k < Samples; k++)
            {
                try 
                {
                    Parallel.For(0, width, new ParallelOptions {CancellationToken = CancellationToken }, i =>
                    {
                        for (int j = 0; j < height; j++)
                        {
                            var sample = sampler.GetSample(k);
                            float u = (i + sample.X) / (width - 1);
                            float v = (j + sample.Y) / (height - 1);
                            Ray ray = camera.GetRay(u, v);
                            image[i, j] += Shade(ray, scene, MaxDepth);
                        }
                    });
                }
                catch(Exception)
                {
                    return;
                }
                if (CancellationToken.IsCancellationRequested)
                    return;

                if (k % _samplesRenderStep == 0 || k == Samples - 1)
                {
                    var output = new Texture(image);
                    output.Process(c => (c / (k + 1)).Clamp());
                    output.AutoGammaCorrect();
                    var percentage = (k + 1) * 100 / Samples;
                    OnFrameReady?.Invoke(percentage, output);
                }
            }
        }
    }
}