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
            this.Position = position;
            UpdateVectors();
        }

        protected override void UpdateViewport()
        {
            float height = (float) (2.0 * Math.Tan(_fov / 2.0));
            float width = height * AspectRatio;

            Horizontal = width * Right;
            Vertical = height * Up;
            LowerLeft = Position - Horizontal / 2 - Vertical / 2 + Front;
        }

        public override Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + Front, Up);
        }

        public override Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 1, FarPlane);
        }

        public override Ray GetRay(float x, float y)
        {
            return new Ray(Position, (LowerLeft + x * Horizontal + y * Vertical - Position).Normalized());
        }
    }
}