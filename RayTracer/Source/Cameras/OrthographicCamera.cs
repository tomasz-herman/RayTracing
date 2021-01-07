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
            this.Position = position;
            UpdateVectors();
        }

        protected override void UpdateViewport()
        {
            float width = Size;
            float height = width / AspectRatio;

            Horizontal = width * Right;
            Vertical = height * Up;
            LowerLeft = Position - Horizontal / 2 - Vertical / 2;
        }

        public override Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + Front, Up);
        }

        public override Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreateOrthographic(Size, Size / AspectRatio, 0, FarPlane);
        }

        public override Ray GetRay(float x, float y)
        {
            return new Ray(LowerLeft + x * Horizontal + y * Vertical, Front);
        }
    }
}