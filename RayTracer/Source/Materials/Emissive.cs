using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using RayTracing.Maths;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public class Emissive : IMaterial
    {
        public ITexture Emit { get; set; }

        public Emissive(ITexture emit)
        {
            Emit = emit;
        }

        public Emissive(Color emitColor)
        {
            Emit = new SolidColor(emitColor);
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            attenuation = Color.FromColor4(Color4.Black);
            scattered = new Ray();
            return false;
        }

        public Color Emitted(float u, float v)
        {
            return Emit[u, v];
        }

        public void Use(Shader shader, float part)
        {
            Emit.Use(shader, "useAmbientColor", "ambientColor", TextureUnit.Texture0);
            shader.SetFloat("ambientPart", part);
        }
    }
}