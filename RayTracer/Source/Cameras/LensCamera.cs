using System;
using System.Collections.Generic;
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
        private Func<int, List<Vector2>> _sampling;
        private int _samplesCount = 64;

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 90f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public float LensRadius
        {
            get => _lensRadius;
            set
            {
                _lensRadius = value;
                UpdateViewport();
            }
        }

        public float FocusDistance
        {
            get => _focusDistance;
            set
            {
                _focusDistance = value;
                UpdateViewport();
            }
        }
        
        public Func<int, List<Vector2>> Sampling
        {
            get => _sampling;
            set
            {
                _sampling = value;
                _lensSampler = new Sampler<Vector2>(_sampling, _samplesCount, 8, Vec2Sampling.ToDisk);
            }
        }
        
        public int SamplesCount
        {
            get => _samplesCount;
            set
            {
                _samplesCount = value;
                _lensSampler = new Sampler<Vector2>(_sampling, _samplesCount, 8, Vec2Sampling.ToDisk);
            }
        }

        public LensCamera(Vector3 position, float lensRadius, float focusDistance, int samplesCount = 64, Func<int, List<Vector2>> sampling = null)
        {
            this.position = position;
            _lensRadius = lensRadius;
            _focusDistance = focusDistance;
            _samplesCount = samplesCount;
            Sampling = sampling ?? Vec2Sampling.Jittered;
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