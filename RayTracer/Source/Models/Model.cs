using OpenTK;
using RayTracer.Materials;
using RayTracer.Maths;

namespace RayTracer.Models
{
    public abstract class Model
    {
        public IMaterial Material;
        public Vector3 Position;
        public float Scale;
        public Vector3 Rotation;

        public abstract HitInfo HitTest(Ray ray, HitInfo hitInfo);
        
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