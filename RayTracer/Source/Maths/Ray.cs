using OpenTK;

namespace RayTracing.Maths
{
    public struct Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;
        public const double Epsilon = 1e-6;

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }
}