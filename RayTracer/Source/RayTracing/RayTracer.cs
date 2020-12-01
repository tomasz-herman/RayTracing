using System;
using RayTracer.Cameras;
using RayTracer.Maths;
using RayTracer.Sampling;
using RayTracer.World;

namespace RayTracer.RayTracing
{
    public class RayTracer
    {
        public int MaxDepth;
        public int AASamples;
        public ISampler AASampler;

        public Color Shade(Scene scene, Ray ray, int depth)
        {
            //TODO ogarnac o co tu chodzi
            if(depth > MaxDepth) return new Color();
            HitInfo hit = scene.HitTest(ray);
            if (hit.ModelHit == null) return scene.AmbientLight.Color;
            return hit.ModelHit.Material.Shade(hit, scene, Shade);
        }

        public void RayTrace(Scene scene, Camera camera)
        {
            throw new NotImplementedException();
        }
    }
}