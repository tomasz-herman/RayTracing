using System.Collections.Generic;
using RayTracing.BVH;
using RayTracing.Lights;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.RayTracing;

namespace RayTracing.World
{
    public class Scene : IHittable
    {
        public bool BvhMode { get; set; } = true;
        public List<Model> Models { get; } = new List<Model>();
        private List<IHittable> Hittables { get; } = new List<IHittable>();
        public AmbientLight AmbientLight { get; set; }

        public void AddModel(Model model)
        {
            Models.Add(model);
        }

        public bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            HitInfo tempHitInfo = new HitInfo();
            bool hitAnything = false;
            float closest = to;

            foreach (var hittable in Hittables)
            {
                if (hittable.HitTest(ray, ref tempHitInfo, from, closest))
                {
                    hitAnything = true;
                    closest = tempHitInfo.Distance;
                    hit = tempHitInfo;
                }
            }

            return hitAnything;
        }

        public AABB BoundingBox()
        {
            throw new System.NotImplementedException();
        }

        private List<IHittable> StandardPreprocess()
        {
            Hittables.Clear();
            foreach (var model in Models)
            {
                Hittables.AddRange(((IHittable) model).Preprocess());
            }

            return Hittables;
        }

        private List<IHittable> BvhPreprocess()
        {
            Hittables.Clear();
            var planes = new List<IHittable>();
            var hittablesToBvh = new List<IHittable>();
            foreach (var model in Models)
            {
                if (model is Plane || model is Cylinder)
                {
                    planes.Add(model);
                }
                else
                {
                    hittablesToBvh.AddRange(((IHittable) model).Preprocess());
                }
            }

            Hittables.AddRange(planes);
            if (hittablesToBvh != null && hittablesToBvh.Count > 0)
            {
                var node = new BvhNode(hittablesToBvh, 0, hittablesToBvh.Count);
                Hittables.Add(node);
            }

            return Hittables;
        }

        public List<IHittable> Preprocess()
        {
            if (BvhMode)
            {
                return BvhPreprocess();
            }
            else
            {
                return StandardPreprocess();
            }
        }

        public override string ToString()
        {
            return "Scene";
        }
    }
}