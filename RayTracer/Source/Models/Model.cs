using RayTracer.Materials;
using RayTracer.Maths;

namespace RayTracer.Models
{
    public abstract class Model
    {
        public IMaterial Material;

        public abstract HitInfo HitTest(Ray ray, HitInfo hitInfo);
        
        public abstract Mesh GetMesh();
    }
}