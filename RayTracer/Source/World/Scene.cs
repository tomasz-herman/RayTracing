using System.Collections.Generic;
using RayTracing.BVH;
using RayTracing.Lights;
using RayTracing.Materials;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.RayTracing;

namespace RayTracing.World
{
    public class Scene : IHittable
    {
        public List<Model> Models { get; } = new List<Model>();
        public List<IHittable> Hittables { get; } = new List<IHittable>();
        public List<IHittable> BetterHittables = new List<IHittable>();
        public BvhNode Node;
        public List<Model> Lights { get; } = new List<Model>();
        public AmbientLight AmbientLight { get; set; }

        public void AddModel(Model model)
        {
            Models.Add(model);
            if (model.Material is Emissive) // add MasterMaterial
            {
                Lights.Add(model);
            }
        }
        
        public bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            HitInfo tempHitInfo = new HitInfo();
            bool hitAnything = false;
            float closest = to;

            //return Node.HitTest(ray, ref hit, from, to);
            foreach (var hittable in BetterHittables)
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

        public bool BoundingBox(out AABB outputBox)
        {
            throw new System.NotImplementedException();
        }

        //TODO: Might do octree/bvh/w\e division here
        public List<IHittable> Preprocess()
        {
            Hittables.Clear();
            BetterHittables.Clear();
            foreach (var model in Models)
            {
                if (model is Plane)
                {
                    BetterHittables.Add(model);
                }
                else
                {
                    Hittables.AddRange(((IHittable)model).Preprocess());
                }
            }

            Node = new BvhNode(Hittables, 0, Hittables.Count);
            BetterHittables.Add(Node);
            return Hittables;
        }
    }
}