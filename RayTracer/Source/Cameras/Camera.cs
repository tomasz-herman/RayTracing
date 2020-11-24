using System;
using OpenTK;

namespace RayTracer.Cameras
{
    public abstract class Camera
    {
        private Vector3 _front = -Vector3.UnitZ;

        private Vector3 _up = Vector3.UnitY;

        private Vector3 _right = Vector3.UnitX;

        protected float _pitch;

        protected float _yaw = -MathHelper.PiOver2;

        protected float _fov = MathHelper.PiOver3;

        public Vector3 Position { get; set; }

        public float AspectRatio { get; set; }
        public float NearPlane { get; set; }
        public float FarPlane { get; set; }

        public Vector3 Front
        {
            get => _front;
            set => _front = Vector3.Normalize(value);
        }

        public Vector3 Up => _up;

        public Vector3 Right => _right;

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(_pitch);
            set
            {
                var angle = MathHelper.Clamp(value, -89f, 89f);
                _pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
            }
        }

        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(_yaw);
            set
            {
                _yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();
            }
        }

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 45f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }
        
        public void Rotate(float dx, float dy, float dz)
        {
            throw new NotImplementedException();
        }

        public void Move(float x, float y, float z)
        {
            throw new NotImplementedException();
        }

        private void UpdateVectors()
        {
            _front.X = (float) Math.Cos(_pitch) * (float) Math.Cos(_yaw);
            _front.Y = (float) Math.Sin(_pitch);
            _front.Z = (float) Math.Cos(_pitch) * (float) Math.Sin(_yaw);

            _front = Vector3.Normalize(_front);

            _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            _up = Vector3.Normalize(Vector3.Cross(_right, _front));
        }

        public abstract Matrix4 GetViewMatrix();
        public abstract Matrix4 GetProjectionMatrix();
        public abstract void GetRay(double x, double y);
    }
}