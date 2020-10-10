using System.Collections.Generic;
using RayTracer.Lights;
using RayTracer.Maths;
using RayTracer.Models;

namespace RayTracer.World
{
    public class Scene
    {
        public List<Model> Models;
        public List<Light> Light;
        public AmbientLight AmbientLight;

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