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
                RotationMatrix = Matrix3.CreateRotationZ(_rotation.Z) * 
                                 Matrix3.CreateRotationY(_rotation.Y) * 
                                 Matrix3.CreateRotationX(_rotation.X);
            }
        }

        protected Matrix3 RotationMatrix = Matrix3.Identity;
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