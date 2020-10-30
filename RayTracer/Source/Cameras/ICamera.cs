using OpenTK;

namespace RayTracer.Cameras
{
    public interface ICamera
    {
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3 Up { get; }
        public float AspectRatio { get; set; }
        public float NearPlane { get; set; }
        public float FarPlane { get; set; }
        public Vector3 Front { get; set; }
        public Vector3 Right { get; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public Matrix4 GetViewMatrix();
        public Matrix4 GetProjectionMatrix();
        public void Rotate(float dx, float dy, float dz);
        public void Move(float x, float y, float z);
        public void GetRay(double x, double y);
    }
}