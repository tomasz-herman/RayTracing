using OpenTK.Graphics.OpenGL4;
using RayTracing.Maths;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public interface ITexture
    {
        Color this[float x, float y] { get; }

        void Use(Shader shader, string useColorUniformName, string colorUniformName, TextureUnit unit);
    }
}