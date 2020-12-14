using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Cameras
{
    public class PerspectiveCamera : Camera
    {
        private float _fov = MathHelper.PiOver3;

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 90f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public PerspectiveCamera(Vector3 position)
        {
            this.position = position;
            UpdateVectors();
        }

        protected override void UpdateViewport()
        {
            float height = (float) (2.0 * Math.Tan(_fov / 2.0));
            float width = height * aspectRatio;

            horizontal = width * right;
            vertical = height * up;
            lowerLeft = position - horizontal / 2 - vertical / 2 + front;
        }

        public override Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(position, position + front, up);
        }

        public override Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 1, FarPlane);
        }

        public override Ray GetRay(float x, float y)
        {
            return new Ray(position, (lowerLeft + x * horizontal + y * vertical - position).Normalized());
        }
    }
}