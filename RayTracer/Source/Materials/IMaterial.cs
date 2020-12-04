using System;
using RayTracing.Maths;
using RayTracing.World;

namespace RayTracing.Materials
{
    public interface IMaterial
    {
        Color Shade(HitInfo hit, Scene scene, Func<Scene, Ray, int, Color> recursiveFunction);
    }
}