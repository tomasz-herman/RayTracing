using System.Collections.Generic;
using RayTracing.Lights;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.RayTracing;

namespace RayTracing.World
{
    public class Scene : IHittable
    {
        public List<Model> Models { get; } = new List<Model>();
        public List<IHittable> Hittables { get; } = new List<IHittable>();
        public List<Light> Lights { get; } = new List<Light>();
        public AmbientLight AmbientLight { get; set; }

        public void AddModel(Model model)
        {
            Models.Add(model);
        }

        public void AddLight(Light light)
        {
            Lights.Add(light);
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
                Hittables.AddRange(((IHittable)model).Preprocess());
            }
            return Hittables;
        }
    }
}