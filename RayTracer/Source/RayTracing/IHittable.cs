using System.Collections.Generic;
using RayTracing.Maths;

namespace RayTracing.RayTracing
{
    public interface IHittable
    {
        bool HitTest(Ray ray, ref HitInfo hit, float from, float to);
        bool BoundingBox(out AABB outputBox);
        List<IHittable> Preprocess();
    }
}