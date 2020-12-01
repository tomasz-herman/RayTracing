using RayTracer.Maths;
using OpenTK;

namespace RayTracer.Lights
{
    public struct Light
    {
        public Vector3 Position;
        public Vector3 Direction;
        public Color Color;
    }
}