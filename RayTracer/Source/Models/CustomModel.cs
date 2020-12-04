using RayTracing.Maths;

namespace RayTracing.Models
{
    public class CustomModel : Model
    {
        private Mesh _mesh;

        public CustomModel(Mesh mesh)
        {
            _mesh = mesh;
        }

        private protected override void LoadInternal()
        {
            _mesh.Load();
        }

        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            throw new System.NotImplementedException();
        }

        public override Mesh GetMesh()
        {
            return _mesh;
        }
        
    }
}