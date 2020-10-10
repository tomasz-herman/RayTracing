using OpenTK;

namespace RayTracer.Cameras
{
    public abstract class ICamera
    {
        public Vector3 Position;
        public Vector3 Direction;
        public Vector3 Up;
        public float AspectRatio;
        public float NearPlane;
        public float FarPlane;

        public abstract Matrix4 GetViewMatrix();
        public abstract Matrix4 GetProjectionMatrix();
        public abstract void Rotate(float dx, float dy, float dz);
        public abstract void Move(float x, float y, float z);
        public abstract void GetRay(double x, double y);
    }
}