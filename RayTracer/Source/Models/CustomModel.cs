using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;
using RayTracing.RayTracing;

namespace RayTracing.Models
{
    public class CustomModel : Model
    {
        public CustomModel()
        {
        }

        public void SetMesh(Mesh mesh)
        {
            Mesh = mesh;
            loaded = false;
        }

        public CustomModel(Mesh mesh)
        {
            Mesh = mesh;
        }

        public override Vector3 Rotation { get; set; }

        private protected override void LoadInternal()
        {
            Mesh.Load();
        }

        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            throw new System.NotImplementedException();
        }

        public override Mesh GetMesh()
        {
            return Mesh;
        }

        public override List<IHittable> Preprocess()
        {
            return MeshToTriangles();
        }

        public override string ToString()
        {
            return "Custom model";
        }
    }
}