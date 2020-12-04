using System;
using RayTracer.Maths;

namespace RayTracer.Materials
{
    public interface IMaterial
    {
        bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered);
    }
}