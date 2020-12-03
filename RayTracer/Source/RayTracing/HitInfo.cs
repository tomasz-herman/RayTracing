using OpenTK;
using RayTracer.Models;

namespace RayTracer.Maths
{
    public struct HitInfo
    {
        public Model ModelHit;
        public float Distance;
        public Vector3 HitPoint;
        public Vector3 Normal;
        public Vector2 TexCoord;
        public Ray ImpactRay;
    }
}