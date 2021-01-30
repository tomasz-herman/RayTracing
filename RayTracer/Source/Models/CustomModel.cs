using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;
using RayTracing.RayTracing;
using Properties = RayTracer.Properties;

namespace RayTracing.Models
{
    public class CustomModel : Model
    {
        public new Mesh Mesh
        {
            get => base.Mesh;
            set
            {
                base.Mesh = value;
                loaded = false;
            }
        }
        
        public CustomModel()
        {
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
            return Properties.Strings.CustomModel;
        }
    }
}