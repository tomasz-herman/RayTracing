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

            foreach (var model in Models)
            {
                if (model.HitTest(ray, ref tempHitInfo, from, closest))
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
            List<IHittable> hittables = new List<IHittable>();
            foreach (var model in Models)
            {
                hittables.AddRange(((IHittable)model).Preprocess());
            }
            return hittables;
        }
    }
}