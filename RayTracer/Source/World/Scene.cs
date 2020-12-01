using System.Collections.Generic;
using RayTracer.Lights;
using RayTracer.Maths;
using RayTracer.Models;

namespace RayTracer.World
{
    public class Scene
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
        
        public HitInfo HitTest(Ray ray)
        {
            HitInfo hit = new HitInfo();
            foreach (var model in Models)
            {
                hit = model.HitTest(ray, hit);
            }
            return hit;
        }
    }
}