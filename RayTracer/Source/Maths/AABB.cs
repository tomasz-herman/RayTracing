using System;
using OpenTK;

namespace RayTracing.Maths
{
    public class AABB
    {
        public Vector3 Min { get; set; }
        public Vector3 Max { get; set; }

        public AABB(Vector3 min, Vector3 max)
        {
            if (min.X > max.X || min.Y > max.Y || min.Z > max.Z)
                throw new ArgumentException("Minimum vector is greater than maximum vector");
            Min = min;
            Max = max;
        }

        public AABB(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            if (xMin > xMax || yMin > yMax || zMin > zMax)
                throw new ArgumentException("Minimum vector is greater than maximum vector");
            Min = new Vector3(xMin, yMin, zMin);
            Max = new Vector3(xMax, yMax, zMax);
        }

        public bool Test(ref Ray ray, float from = 0, float to = float.PositiveInfinity)
        {
            for (int a = 0; a < 3; a++)
            {
                float invD = 1.0f / ray.Direction[a];
                float t0 = (Min[a] - ray.Origin[a]) * invD;
                float t1 = (Max[a] - ray.Origin[a]) * invD;
                if (invD < 0.0f)
                    (t0, t1) = (t1, t0);
                from = t0 > from ? t0 : from;
                to = t1 < to ? t1 : to;
                if (to <= from)
                    return false;
            }

            return true;
        }

        public static AABB operator +(AABB first, AABB second)
        {
            return new AABB(Vector3.ComponentMin(first.Min, second.Min),
                Vector3.ComponentMax(first.Max, second.Max));
        }
    }
}