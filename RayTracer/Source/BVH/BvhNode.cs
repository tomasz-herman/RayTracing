using System;
using System.Collections.Generic;
using RayTracing.Maths;
using RayTracing.RayTracing;
using RayTracing.Sampling;

namespace RayTracing.BVH
{
    public class BvhNode : IHittable
    {
        private const int SAMPLES = 10000;
        private readonly IHittable _left;
        private readonly IHittable _right;
        private readonly AABB _box;

        // https://raytracing.github.io/books/RayTracingTheNextWeek.html#boundingvolumehierarchies
        public BvhNode(List<IHittable> srcObjects, int start, int end, AbstractSampler<int> sampler = null)
        {
            sampler ??= new ThreadSafeSampler<int>(count => IntSampling.Random(count, 0, 3), SAMPLES);

            var objects = srcObjects;
            int axis = sampler.GetSample();
            int Comparator(IHittable a, IHittable b) => BoxCompare(a, b, axis);

            int objectSpan = end - start;
            if (objectSpan == 1)
            {
                _left = _right = objects[start];
            }
            else if (objectSpan == 2)
            {
                if (Comparator(objects[start], objects[start + 1]) < 0)
                {
                    _left = objects[start];
                    _right = objects[start + 1];
                }
                else
                {
                    _left = objects[start + 1];
                    _right = objects[start];
                }
            }
            else
            {
                objects.Sort(start, objectSpan - 1, new FuncComparer<IHittable>(Comparator));
                int mid = start + objectSpan / 2;
                _left = new BvhNode(objects, start, mid, sampler);
                _right = new BvhNode(objects, mid, end, sampler);
            }

            var boxLeft = _left.BoundingBox();
            var boxRight = _right.BoundingBox();

            _box = boxLeft + boxRight;
        }

        public bool HitTest(Ray ray, ref HitInfo hit, float @from, float to)
        {
            if (!_box.Test(ref ray, from, to))
                return false;

            bool hitLeft = _left.HitTest(ray, ref hit, from, to);
            bool hitRight = _right.HitTest(ray, ref hit, from, hitLeft ? hit.Distance : to);

            return hitLeft || hitRight;
        }

        public AABB BoundingBox()
        {
            return _box;
        }

        public List<IHittable> Preprocess()
        {
            throw new System.NotImplementedException();
        }

        private int BoxCompare(IHittable a, IHittable b, int axis)
        {
            var boxA = a.BoundingBox();
            var boxB = b.BoundingBox();

            return boxA.Min[axis].CompareTo(boxB.Min[axis]);
        }

        private class FuncComparer<T> : IComparer<T>
        {
            private readonly Func<T, T, int> _func;

            public FuncComparer(Func<T, T, int> comparerFunc)
            {
                _func = comparerFunc;
            }

            public int Compare(T x, T y)
            {
                return _func(x, y);
            }
        }
    }
}