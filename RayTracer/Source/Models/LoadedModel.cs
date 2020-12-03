using RayTracer.Maths;

namespace RayTracer.Models
{
    public class LoadedModel : Model
    {
        public Mesh mesh;

        public LoadedModel(Mesh mesh)
        {
            this.mesh = mesh;
        }
        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            throw new System.NotImplementedException();
        }

        public override Mesh GetMesh()
        {
            return mesh;
        }
        
    }
}