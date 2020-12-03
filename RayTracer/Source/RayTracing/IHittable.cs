using RayTracer.Maths;

namespace RayTracer.RayTracing
{
    public interface IHittable
    {
        bool HitTest(Ray ray, ref HitInfo hit, float from, float to);
    }
}