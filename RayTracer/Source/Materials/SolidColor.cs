using RayTracing.Maths;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public class SolidColor : ITexture
    {
        public Color Color;

        public SolidColor(Color color)
        {
            Color = color;
        }

        public Color this[float x, float y] => Color;

        public void Use(Shader shader)
        {
            shader.SetInt("singleColor", 1);
            shader.SetVector3("materialColor", Color.ToVector3());
        }
    }
}