using System;
using System.Collections.Generic;
using RayTracer.Lights;
using RayTracer.Maths;
using RayTracer.Models;
using RayTracer.RayTracing;

namespace RayTracer.World
{
    public class Scene : IHittable
    {
        public List<Model> Models = new List<Model>();
        public List<Light> Lights = new List<Light>();
        public AmbientLight AmbientLight;

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
    }
}