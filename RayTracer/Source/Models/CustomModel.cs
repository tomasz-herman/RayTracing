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
            base.Mesh = mesh;
            loaded = false;
        }

        public CustomModel(Mesh mesh)
        {
            base.Mesh = mesh;
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
            List<IHittable> hittables = new List<IHittable>();
            if (Mesh == null) return hittables;

            Matrix4 modelMatrix = GetModelMatrix();
            
            for (var index = 0; index < Mesh.Indices.Count; index+=3)
            {
                Vector3 v1 = Mesh.GetPostion(index);
                Vector3 v2 = Mesh.GetPostion(index + 1);
                Vector3 v3 = Mesh.GetPostion(index + 2);
                Vector2 tc1 = Mesh.GetTexCoord(index);
                Vector2 tc2 = Mesh.GetTexCoord(index + 1);
                Vector2 tc3 = Mesh.GetTexCoord(index + 2);
                v1 = (new Vector4(v1, 1.0f) * modelMatrix).Xyz;
                v2 = (new Vector4(v2, 1.0f) * modelMatrix).Xyz;
                v3 = (new Vector4(v3, 1.0f) * modelMatrix).Xyz;
                Triangle t = new Triangle(v1, v2, v3, tc1, tc2, tc3);
                hittables.Add(t);
            }

            return hittables;
        }
    }
}