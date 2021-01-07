using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;
using RayTracing.World;

namespace RayTracing
{
    public abstract class RayTracer
    {
        public int MaxDepth { get; set; }
        public int Samples { get; set; }
        public Func<int, List<Vector2>> Sampling { get; set; }
        public int Resolution { get; set; }

        public int Bloom { get; set; }

        public int GammaCorrection { get; set; }

        public RayTracer(int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution)
        {
            MaxDepth = maxDepth;
            Samples = samples;
            Sampling = sampling;
            Resolution = resolution;
        }

        public Color Shade(Ray ray, Scene scene, int depth)
        {
            if (depth == 0) return new Color();

            HitInfo hitInfo = new HitInfo();

            if (scene.HitTest(ray, ref hitInfo, 0.001f, float.PositiveInfinity))
            {
                var emitted =
                    hitInfo.ModelHit.Material.Emitted(hitInfo.TexCoord.X, hitInfo.TexCoord.Y);

                if (hitInfo.ModelHit.Material.Scatter(ref ray, ref hitInfo, out Color attenuation, out Ray scattered))
                {
                    return emitted + attenuation * Shade(scattered, scene, depth - 1);
                }

                return emitted;
            }

            return scene.AmbientLight.Color;
        }
    }
}