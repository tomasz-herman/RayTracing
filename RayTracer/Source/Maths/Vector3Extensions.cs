using OpenTK;

namespace RayTracing.Maths
{
    public static class Vector3Extensions
    {
        public static Vector3 reflect(this Vector3 vector, Vector3 normal)
        {
            return vector - 2 * Vector3.Dot(vector, normal) * normal;
        }
    }
}