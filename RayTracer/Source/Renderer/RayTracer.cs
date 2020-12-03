using System;
using RayTracer.Cameras;
using RayTracer.Maths;
using RayTracer.Sampling;
using RayTracer.Utils;
using RayTracer.World;

namespace RayTracer.RayTracing
{
    public class RayTracer : IRenderer
    {
        public int MaxDepth;
        public int Samples;
        public ISampler Sampler;
        public int Resolution;

        public void Render(Scene scene, Camera camera)
        {
            int width = Resolution;
            int height = (int) (width / camera.AspectRatio);
            Image image = new Image(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < Samples; k++)
                    {
                        var sample = Sampler.Sample();
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
            if(depth == 0) return new Color();
            
            HitInfo hitInfo = new HitInfo();

            if (scene.HitTest(ray, ref hitInfo, 0.001f, float.PositiveInfinity))
            {
                // TODO: Shade recursively using material
                return new Color(1, 0, 0);
            }

            return scene.AmbientLight.Color;
        }
    }
}