using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Cameras;
using RayTracing.World;

namespace RayTracing
{
    public class RecursionRayTracer : SamplesRayTracer
    {
        public RecursionRayTracer(int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution, int renderStep) : base(
            maxDepth, samples, sampling, resolution, renderStep)
        {
        }

        public override void Render(Scene scene, Camera camera)
        {
            var maxDepth = MaxDepth;
            for (int recDepth = 1; recDepth <= maxDepth; recDepth++)
            {
                MaxDepth = recDepth;
                base.Render(scene, camera);
            }
        }
    }
}