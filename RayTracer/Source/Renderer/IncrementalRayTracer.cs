using System;
using System.Collections.Generic;
using System.Threading;
using OpenTK;
using RayTracing.Cameras;
using RayTracing.World;

namespace RayTracing
{
    public abstract class IncrementalRayTracer : RayTracer, IRenderer
    {
        public Action<int, object> OnFrameReady { get; set; }
        public CancellationToken CancellationToken { get; set; }

        public int SamplesRenderStep { get; set; }
        public abstract void Render(Scene scene, Camera camera);

        public IncrementalRayTracer(int maxDepth, int samples, Func<int, List<Vector2>> sampling, int resolution, int samplesRenderStep) :
            base(maxDepth, samples, sampling, resolution)
        {
            SamplesRenderStep = samplesRenderStep;
        }
    }
}