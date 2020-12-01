using System;
using RayTracer.Maths;
using RayTracer.World;

namespace RayTracer.Materials
{
    public interface IMaterial
    {
        Color Shade(HitInfo hit, Scene scene, Func<Scene, Ray, int, Color> recursiveFunction);
    }
}