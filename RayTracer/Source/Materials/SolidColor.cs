using OpenTK.Graphics.OpenGL4;
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

        public void Use(Shader shader, string useColorUniformName, string colorUniformName, TextureUnit unit)
        {
            shader.SetInt(useColorUniformName, 1);
            shader.SetVector3(colorUniformName, Color.ToVector3());
        }
    }
}