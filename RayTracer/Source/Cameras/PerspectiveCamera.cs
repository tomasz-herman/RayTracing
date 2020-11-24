using System;
using OpenTK;

namespace RayTracer.Cameras
{
    public class PerspectiveCamera : Camera
    {
        public override Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + Front, Up);
        }

        public override Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 0.01f, 100f);
        }

        public override void GetRay(double x, double y)
        {
            throw new NotImplementedException();
        }
    }
}


