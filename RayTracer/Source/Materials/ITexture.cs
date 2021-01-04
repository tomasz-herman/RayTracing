using OpenTK.Graphics.OpenGL4;
using RayTracing.Maths;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public interface ITexture
    {
        Color this[float x, float y] { get; }

        void Use(Shader shader, int matNum, float part);
        
        static string MaterialUseColorUniformName(int matNum)
        {
            return $"materials[{matNum}].useColor";
        }
        
        static string MaterialColorUniformName(int matNum)
        {
            return $"materials[{matNum}].color";
        }
        
        static string MaterialPartUniformName(int matNum)
        {
            return $"materials[{matNum}].part";
        }
        
        static TextureUnit MaterialTextureUnit(int matNum)
        {
            return TextureUnit.Texture0 + matNum;
        }
    }
}