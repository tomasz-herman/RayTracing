using System;
using OpenTK;

namespace RayTracer.Cameras
{
    public abstract class Camera
    {
        protected Vector3 _front = -Vector3.UnitZ;
        protected Vector3 _up = Vector3.UnitY;
        protected Vector3 _right = Vector3.UnitX;
        protected float _pitch;
        protected float _yaw = -MathHelper.PiOver2;

        protected float _fov = MathHelper.PiOver3;
        protected Vector3 position;

        public float AspectRatio { get; set; }
        public float NearPlane { get; set; }
        public float FarPlane { get; set; }

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 45f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }
        
        public void Rotate(float dpitch, float dyaw, float droll)
        {
            _pitch += dpitch;
            _yaw += dyaw;
            UpdateVectors();
        }

        public void Move(float dx, float dy, float dz)
        {
            position += _front * dz+_up*dy+_right*dx;
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