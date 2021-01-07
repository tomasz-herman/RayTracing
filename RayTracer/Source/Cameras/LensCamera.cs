using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Cameras
{
    public class LensCamera : Camera
    {
        private const int SAMPLE_SETS = 8;

        private float _lensRadius;
        private float _focusDistance;
        private AbstractSampler<Vector2> _lensSampler;
        private Func<int, List<Vector2>> _sampling;
        private int _samplesCount;

        public bool AutoFocus { get; set; }

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
                _lensSampler =
                    new ThreadSafeSampler<Vector2>(_sampling, _samplesCount, SAMPLE_SETS, Vec2Sampling.ToDisk);
            }
        }

        public int SamplesCount
        {
            get => _samplesCount;
            set
            {
                _samplesCount = value;
                _lensSampler =
                    new ThreadSafeSampler<Vector2>(_sampling, _samplesCount, SAMPLE_SETS, Vec2Sampling.ToDisk);
            }
        }

        public LensCamera(Vector3 position, float lensRadius = 0.25f, float focusDistance = 5, int samplesCount = 10000,
            Func<int, List<Vector2>> sampling = null)
        {
            Position = position;
            _lensRadius = lensRadius;
            _focusDistance = focusDistance;
            _samplesCount = samplesCount;
            Sampling = sampling ?? Vec2Sampling.Jittered;
            UpdateVectors();
        }

        protected override void UpdateViewport()
        {
            float height = (float) (2.0 * Math.Tan(_fov / 2.0));
            float width = height * AspectRatio;

            Horizontal = width * Right * _focusDistance;
            Vertical = height * Up * _focusDistance;
            LowerLeft = Position - Horizontal / 2 - Vertical / 2 + Front * _focusDistance;
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
            Vector2 rd = _lensRadius * _lensSampler.Sample;
            Vector3 offset = Right * rd.X + Up * rd.Y;

            return new Ray(Position + offset,
                (LowerLeft + x * Horizontal + y * Vertical - Position - offset).Normalized());
        }
    }
}