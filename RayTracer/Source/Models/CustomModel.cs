using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class CustomModel : Model
    {
        public CustomModel()
        {
        }

        public void SetMesh(Mesh mesh)
        {
            base.mesh = mesh;
            loaded = false;
        }

        public CustomModel(Mesh mesh)
        {
            base.mesh = mesh;
        }

        public override Vector3 Rotation { get; set; }

        private protected override void LoadInternal()
        {
            mesh.Load();
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