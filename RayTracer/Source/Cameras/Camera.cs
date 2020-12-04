using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Cameras
{
    public abstract class Camera
    {
        private protected Vector3 front = -Vector3.UnitZ;
        private protected Vector3 up = Vector3.UnitY;
        private protected Vector3 right = Vector3.UnitX;
        private protected float pitch;
        private protected float yaw = -MathHelper.PiOver2;
        private protected float farPlane = 1000f;
        private protected float fov = MathHelper.PiOver3;
        private protected float aspectRatio = 16f / 9;
        private protected Vector3 position;
        private protected Vector3 horizontal;
        private protected Vector3 vertical;
        private protected Vector3 upperLeft;

        public float AspectRatio
        {
            get => aspectRatio;
            set
            {
                aspectRatio = value;
                UpdateVectors();
            }
        }

        public float FarPlane
        {
            get => farPlane;
            set => farPlane = value;
        }

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 90f);
                fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public void Rotate(float dpitch, float dyaw, float droll)
        {
            pitch += dpitch;
            yaw += dyaw;
            UpdateVectors();
        }

        public void Move(float dx, float dy, float dz)
        {
            position += front * dz + up * dy + right * dx;
        }

        private void UpdateVectors()
        {
            front.X = (float) Math.Cos(pitch) * (float) Math.Cos(yaw);
            front.Y = (float) Math.Sin(pitch);
            front.Z = (float) Math.Cos(pitch) * (float) Math.Sin(yaw);

            front = Vector3.Normalize(front);

            right = Vector3.Normalize(Vector3.Cross(front, Vector3.UnitY));
            up = Vector3.Normalize(Vector3.Cross(right, front));

            float width = (float) (2.0 * Math.Tan(fov / 2.0));
            float height = width / aspectRatio;

            var w = (position - front).Normalized();
            var u = Vector3.Cross(up, w).Normalized();
            var v = Vector3.Cross(w, u);

            horizontal = width * u;
            vertical = height * v;
            upperLeft = position - horizontal / 2 + vertical / 2 - w;
        }

        public abstract Matrix4 GetViewMatrix();
        public abstract Matrix4 GetProjectionMatrix();
        public abstract Ray GetRay(float x, float y);
    }
}