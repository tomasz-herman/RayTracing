using System;
using OpenTK;
using RayTracer.Maths;

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
        private float _aspectRatio;
        protected Vector3 position;
        protected Vector3 horizontal;
        protected Vector3 vertical;
        protected Vector3 upperLeft; 

        public float AspectRatio
        {
            get => _aspectRatio;
            set
            {
                _aspectRatio = value;
                UpdateVectors();
            }
        }

        public float NearPlane { get; set; }
        public float FarPlane { get; set; }

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 90f);
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
            position += _front * dz + _up * dy + _right * dx;
        }

        private void UpdateVectors()
        {
            _front.X = (float) Math.Cos(_pitch) * (float) Math.Cos(_yaw);
            _front.Y = (float) Math.Sin(_pitch);
            _front.Z = (float) Math.Cos(_pitch) * (float) Math.Sin(_yaw);

            _front = Vector3.Normalize(_front);

            _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            _up = Vector3.Normalize(Vector3.Cross(_right, _front));
            
            float width = (float)(2.0 * Math.Tan(_fov / 2.0));
            float height = width / _aspectRatio;

            var w = (position - _front).Normalized();
            var u = Vector3.Cross(_up,w).Normalized();
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