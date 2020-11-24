using OpenTK;

namespace RayTracer.Cameras
{
    public interface ICamera
    {
        Vector3 Position { get; set; }
        Vector3 Direction { get; set; }
        Vector3 Up { get; }
        float AspectRatio { get; set; }
        float NearPlane { get; set; }
        float FarPlane { get; set; }
        Vector3 Front { get; set; }
        Vector3 Right { get; }
        float Yaw { get; set; }
        float Pitch { get; set; }

        Matrix4 GetViewMatrix();
        Matrix4 GetProjectionMatrix();
        void Rotate(float dx, float dy, float dz);
        void Move(float x, float y, float z);
        void GetRay(double x, double y);
    }
}