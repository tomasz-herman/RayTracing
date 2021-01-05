using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Cameras
{
    public abstract class Camera
    {
        protected Vector3 Front { get; set; } = -Vector3.UnitZ;
        protected Vector3 Up { get; set; } = Vector3.UnitY;
        protected Vector3 Right { get; set; } = Vector3.UnitX;
        protected float Pitch { get; set; }
        protected float Yaw  { get; set; } = -MathHelper.PiOver2;
        private float _aspectRatio = 16f / 9;
        public Vector3 Position { get; set; }
        protected Vector3 Horizontal { get; set; }
        protected Vector3 Vertical { get; set; }
        protected Vector3 LowerLeft { get; set; }
        
        public float FarPlane { get; set; } = 1000f;

        public float AspectRatio
        {
            get => _aspectRatio;
            set
            {
                _aspectRatio = value;
                UpdateVectors();
            }
        }

        public void Rotate(float dpitch, float dyaw, float droll)
        {
            // TODO: implement roll
            Pitch += dpitch;
            Yaw += dyaw;
            UpdateVectors();
        }

        public void Move(float dx, float dy, float dz)
        {
            Position += Front * dz + Up * dy + Right * dx;
            UpdateViewport();
        }

        protected abstract void UpdateViewport();

        protected void UpdateVectors()
        {
            Front = new Vector3
            {
                X = (float) Math.Cos(Pitch) * (float) Math.Cos(Yaw),
                Y = (float) Math.Sin(Pitch),
                Z = (float) Math.Cos(Pitch) * (float) Math.Sin(Yaw)
            };

            Front = Vector3.Normalize(Front);
            Right = Vector3.Normalize(Vector3.Cross(Front, Vector3.UnitY));
            Up = Vector3.Normalize(Vector3.Cross(Right, Front));

            UpdateViewport();
        }

        public abstract Matrix4 GetViewMatrix();
        public abstract Matrix4 GetProjectionMatrix();
        public abstract Ray GetRay(float x, float y);
    }
}