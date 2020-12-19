using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Materials
{
    public interface IMaterial
    {
        bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered);
        public Color Emitted(double u, double v, ref Vector3 p)
        {
            return new Color(0, 0, 0);
        }
    }
}