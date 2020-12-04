using RayTracing.Maths;

namespace RayTracing.RayTracing
{
    public interface IHittable
    {
        bool HitTest(Ray ray, ref HitInfo hit, float from, float to);
    }
}