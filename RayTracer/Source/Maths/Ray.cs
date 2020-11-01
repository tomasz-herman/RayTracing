using OpenTK;

namespace RayTracer.Maths
{
    public struct Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;
        public const double Epsilon = 1e-6;
    }
}