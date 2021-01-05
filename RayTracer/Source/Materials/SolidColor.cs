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

        public void Use(Shader shader, int matNum, float part)
        {
            shader.SetInt(ITexture.MaterialUseColorUniformName(matNum), 1);
            shader.SetVector3(ITexture.MaterialColorUniformName(matNum), Color.ToVector3());
            shader.SetFloat(ITexture.MaterialPartUniformName(matNum), part);
        }
    }
}