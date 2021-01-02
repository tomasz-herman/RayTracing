using RayTracing.Maths;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public interface IMaterial
    {
        bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered);

        Color Emitted(float u, float v)
        {
            return new Color(0, 0, 0);
        }

        void Use(Shader shader, float part);
    }
}