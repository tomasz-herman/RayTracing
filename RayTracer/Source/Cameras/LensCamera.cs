using System;
using OpenTK;
using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Cameras
{
    public class LensCamera : Camera
    {
        private float _fov = MathHelper.PiOver3;
        private float _lensRadius;
        private float _focusDistance;
        private Sampler<Vector2> _lensSampler;

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 90f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public LensCamera(Vector3 position, float lensRadius, float focusDistance, Sampler<Vector2> lensSampler = null)
        {
            this.position = position;
            _lensRadius = lensRadius;
            _focusDistance = focusDistance;
            _lensSampler = lensSampler ?? new Sampler<Vector2>(Vec2Sampling.Jittered, 100, 8, Vec2Sampling.ToDisk);
            UpdateVectors();
        }

        protected override void UpdateViewport()
        {
            float width = (float) (2.0 * Math.Tan(_fov / 2.0));
            float height = width / aspectRatio;

            horizontal = width * right * _focusDistance;
            vertical = height * up * _focusDistance;
            lowerLeft = position - horizontal / 2 - vertical / 2 + front * _focusDistance;
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
            Vector2 rd = _lensRadius * _lensSampler.Sample;
            Vector3 offset = right * rd.X + up * rd.Y;
            
            return new Ray(position + offset, (lowerLeft + x * horizontal + y * vertical - position - offset).Normalized());
        }
    }
}