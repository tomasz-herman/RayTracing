using System;
using System.Collections.Generic;
using RayTracing.Maths;
using RayTracing.RayTracing;

namespace RayTracing.BVH
{
    public class BvhNode : IHittable
    {
        public IHittable Left;
        public IHittable Right;
        public AABB Box;
        
        public BvhNode()
        {
        }

        public BvhNode(HittableList list) : this(list.Hittables, 0, list.Hittables.Count)
        {
        }

        public BvhNode(List<IHittable> srcObjects, int start, int end)
        {
            var objects = srcObjects;
            var random = new Random();
            int axis = random.Next(0, 2);
            Func<IHittable, IHittable, int> comparator = null;
            if (axis == 0) comparator = box_x_compare;
            else if (axis == 1) comparator = box_y_compare;
            else if (axis == 2) comparator = box_z_compare;

            int object_span = end - start;
            if (object_span == 1)
            {
                Left = Right = objects[start];
            }
            else if (object_span == 2)
            {
                if (comparator(objects[start], objects[start + 1]) < 0)
                {
                    Left = objects[start];
                    Right = objects[start + 1];
                }
                else
                {
                    Left = objects[start + 1];
                    Right = objects[start];
                }
            }
            else
            {
                objects.Sort(start, object_span-1, new FuncComparer<IHittable>(comparator));
                int mid = start + object_span / 2;
                Left = new BvhNode(objects, start, mid);
                Right = new BvhNode(objects, mid, end);
            }

            AABB boxLeft;
            AABB boxRight;

            if (!Left.BoundingBox(out boxLeft) || !Right.BoundingBox(out boxRight))
            {
                throw new Exception("No bounding box in constructor");
            }

            Box = HittableList.SurroundingBox(boxLeft, boxRight);
        }

        public bool HitTest(Ray ray, ref HitInfo hit, float @from, float to)
        {
            if (!Box.Test(ref ray, from, to))
                return false;

            bool hitLeft = Left.HitTest(ray, ref hit, from, to);
            bool hitRight = Right.HitTest(ray, ref hit, from, hitLeft ? hit.Distance : to);

            return hitLeft || hitRight;
        }

        public bool BoundingBox(out AABB outputBox)
        {
            outputBox = Box;
            return true;
        }

        public List<IHittable> Preprocess()
        {
            throw new System.NotImplementedException();
        }

        private class FuncComparer<T> : IComparer<T>
        {
            private readonly Func<T, T, int> func;
            public FuncComparer(Func<T, T, int> comparerFunc)
            {
                func = comparerFunc;
            }

            public int Compare(T x, T y)
            {
                return func(x, y);
            }
        }
        int box_compare(IHittable a, IHittable b, int axis)
        {
            AABB box_a;
            AABB box_b;

            if (!a.BoundingBox(out box_a) || !b.BoundingBox(out box_b))
            {
                throw new Exception("No bounding box in bvh_node constructor.\n");
            }

            
            return box_a.Min[axis].CompareTo(box_b.Min[axis]);
        }


        int box_x_compare (IHittable a, IHittable b) {
            return box_compare(a, b, 0);
        }

        int box_y_compare (IHittable a, IHittable b) {
            return box_compare(a, b, 1);
        }

        int box_z_compare (IHittable a, IHittable b) {
            return box_compare(a, b, 2);
        }
    }
}