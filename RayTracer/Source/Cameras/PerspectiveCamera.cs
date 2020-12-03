using System;
using OpenTK;
using RayTracer.Maths;

namespace RayTracer.Cameras
{
    public class PerspectiveCamera : Camera
    {
        public PerspectiveCamera(Vector3 position)
        {
            this.position = position;
        }

        public override Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(position, position + front, up);
        }

        public override Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(fov, AspectRatio, 1, FarPlane);
        }

        public override Ray GetRay(float x, float y)
        {
            return new Ray(position, (upperLeft + x * horizontal - y * vertical - position).Normalized());
        }
    }
}