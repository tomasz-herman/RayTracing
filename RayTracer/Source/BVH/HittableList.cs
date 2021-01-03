using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;
using RayTracing.RayTracing;

namespace RayTracing.BVH
{
    public class HittableList : IHittable
    {
        public List<IHittable> Hittables;

        public bool HitTest(Ray ray, ref HitInfo hit, float @from, float to)
        {
            throw new System.NotImplementedException();
        }

        public bool BoundingBox(out AABB outputBox)
        {
            bool firstBox = true;

            outputBox = new AABB(Vector3.One, Vector3.One);
            foreach (var hittable in Hittables)
            {
                if (!hittable.BoundingBox(out var tempBox)) return false;
                outputBox = firstBox ? tempBox : SurroundingBox(outputBox, tempBox);
                firstBox = false;
            }
            return true;
        }

        public List<IHittable> Preprocess()
        {
            throw new System.NotImplementedException();
        }

        public static AABB SurroundingBox(AABB box0, AABB box1)
        {
            var small = new Vector3(Math.Min(box0.Min.X, box1.Min.X),
                Math.Min(box0.Min.Y, box1.Min.Y),
                Math.Min(box0.Min.Z, box1.Min.Z));

            var big = new Vector3(Math.Max(box0.Max.X, box1.Max.X),
                Math.Max(box0.Max.Y, box1.Max.Y),
                Math.Max(box0.Max.Z, box1.Max.Z));

            return new AABB(small, big);
        }
    }
}