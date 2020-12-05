using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Cameras;
using RayTracing.Maths;
using RayTracing.Sampling;
using RayTracing.Utils;
using RayTracing.World;

namespace RayTracing
{
    public class RayTracer : IRenderer
    {
        public int MaxDepth=1;
        public int Samples;
        public Func<int, List<Vector2>> Sampling;
        public int Resolution;

        public RayTracer(int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution)
        {
            MaxDepth = maxDepth;
            Samples = samples;
            Sampling = sampling;
            Resolution = resolution;
        }

        public void Render(Scene scene, Camera camera)
        {
            int width = Resolution;
            int height = (int) (width / camera.AspectRatio);
            Image image = new Image(width, height);
            Sampler<Vector2> sampler = new Sampler<Vector2>(Sampling, Samples);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < Samples; k++)
                    {
                        var sample = sampler.Sample;
                        float u = (i + sample.X) / (width - 1);
                        float v = (j + sample.Y) / (height - 1);
                        Ray ray = camera.GetRay(u, v);
                        image[i, j] += Shade(ray, scene, MaxDepth);
                    }
                }
            }

            image.Process(c => c / Samples);
            // TODO: Get image raw data and load it to graphics card
            image.Write("RenderedScene.png");
        }

        public Color Shade(Ray ray, Scene scene, int depth)
        {
            if (depth == 0) return new Color();

            HitInfo hitInfo = new HitInfo();

            if (scene.HitTest(ray, ref hitInfo, 0.001f, float.PositiveInfinity))
            {
                if(hitInfo.ModelHit.Material.Scatter(ref ray, ref hitInfo, out Color attenuation, out Ray scattered)) {
                    return attenuation * Shade(scattered, scene, depth - 1);
                }
                return new Color();
            }

            return scene.AmbientLight.Color;
        }
    }
}