using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Lights
{
    public struct Light
    {
        public Vector3 Position;
        public Vector3 Direction;
        public Color Color;
    }
}