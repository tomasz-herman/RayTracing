using System;
using RayTracing.Maths;

namespace RayTracing.Materials
{
    public interface IMaterial
    {
        bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered);
    }
}