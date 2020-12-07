using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Cameras
{
    public class OrthographicCamera : Camera
    {
        private float _size = 10.0f;

        public float Size
        {
            get => _size;
            set
            {
                _size = value;
                UpdateViewport();
            }
        }

        public OrthographicCamera(Vector3 position)
        {
            this.position = position;
            UpdateVectors();
        }

        protected override void UpdateViewport()
        {
            float width = Size;
            float height = width / aspectRatio;

            horizontal = width * right;
            vertical = height * up;
            lowerLeft = position - horizontal / 2 - vertical / 2;
        }

        public override Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(position, position + front, up);
        }

        public override Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreateOrthographic(Size, Size / aspectRatio, 0, FarPlane);
        }

        public override Ray GetRay(float x, float y)
        {
            return new Ray(lowerLeft + x * horizontal + y * vertical, front);
        }
    }
}