using OpenTK;
using RayTracing.Maths;
using RayTracing.Models;

namespace RayTracing
{
    public struct HitInfo
    {
        public Model ModelHit;
        public float Distance;
        public Vector3 HitPoint;
        public Vector3 Normal;
        public Vector2 TexCoord;
        public bool FrontFace;

        public void SetNormal(ref Ray ray, ref Vector3 normal) {
            FrontFace = Vector3.Dot(ray.Direction, normal) <= 0;
            Normal = FrontFace ? normal : -normal;
        }
    }
}