using System.Collections.Generic;
using OpenTK;
using RayTracing.Materials;
using RayTracing.Maths;
using RayTracing.RayTracing;

namespace RayTracing.Models
{
    public abstract class Model : IHittable
    {
        protected Mesh Mesh { get; set; }
        protected bool loaded;
        private Vector3 _rotation;

        public bool Loaded => loaded;
        public IMaterial Material;
        public virtual Vector3 Position { get; set; }
        public virtual float Scale { get; set; } = 1f;

        public virtual Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                UpdateRotationMatrix(value);
            }
        }

        protected virtual Matrix3 RotationMatrix { get; set; } = Matrix3.Identity;

        public Model()
        {
            Material = new MasterMaterial();
        }     
        
        protected void UpdateRotationMatrix(Vector3 newRotation)
        {
            RotationMatrix = Matrix3.CreateRotationX(newRotation.X) *
                             Matrix3.CreateRotationY(newRotation.Y) *
                             Matrix3.CreateRotationZ(newRotation.Z);
        }

        private protected abstract void LoadInternal();

        public Model Load()
        {
            LoadInternal();
            loaded = true;
            return this;
        }

        public Model Unload()
        {
            Mesh?.Unload();
            loaded = false;
            return this;
        }

        public abstract bool HitTest(Ray ray, ref HitInfo hit, float from, float to);

        public virtual AABB BoundingBox()
        {
            throw new System.NotImplementedException();
        }

        public virtual List<IHittable> Preprocess()
        {
            return new List<IHittable> {this};
        }

        public List<IHittable> MeshToTriangles()
        {
            List<IHittable> hittables = new List<IHittable>();
            if (Mesh == null) return hittables;

            Matrix4 modelMatrix = GetModelMatrix();

            for (var index = 0; index < Mesh.Indices.Count; index += 3)
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
                t.Material = Material;
                hittables.Add(t);
            }

            return hittables;
        }

        public abstract Mesh GetMesh();

        public Matrix4 GetModelMatrix()
        {
            Matrix4 modelMatrix = Matrix4.Identity;

            modelMatrix *= Matrix4.CreateScale(Scale);
            modelMatrix *= Matrix4.CreateRotationX(Rotation.X);
            modelMatrix *= Matrix4.CreateRotationY(Rotation.Y);
            modelMatrix *= Matrix4.CreateRotationZ(Rotation.Z);
            modelMatrix *= Matrix4.CreateTranslation(Position);

            return modelMatrix;
        }
    }
}