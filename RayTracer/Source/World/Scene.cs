using System.Collections.Generic;
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
        public List<Model> Lights { get; } = new List<Model>();
        public AmbientLight AmbientLight { get; set; }

        public void AddModel(Model model)
        {
            Models.Add(model);
            if (model.Material is Emissive || model.Material is MasterMaterial &&
                (model.Material as MasterMaterial).Parts.emissive != 0) // add MasterMaterial
            {
                Lights.Add(model);
            }
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

        //TODO: Might do octree/bvh/w\e division here
        public List<IHittable> Preprocess()
        {
            Hittables.Clear();
            foreach (var model in Models)
            {
                Hittables.AddRange(((IHittable) model).Preprocess());
            }

            return Hittables;
        }
    }
}