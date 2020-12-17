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
    public class FileRayTracer : RayTracer, IRenderer
    {
        private string _path;

        public FileRayTracer(string path, int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution) : base(
            maxDepth, samples, sampling, resolution)
        {
            _path = path;
        }

        public void Render(Scene scene, Camera camera)
        {
            int width = Resolution;
            int height = (int) (width / camera.AspectRatio);
            var image = new Texture(width, height);
            AbstractSampler<Vector2> sampler = new Sampler<Vector2>(Sampling, Samples);
            for (int k = 0; k < Samples; k++)
            {
                Parallel.For(0, width, i =>
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

            image.Process(c => c / Samples);
            image.Write(_path);
        }
    }
}