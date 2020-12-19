using OpenTK;
using OpenTK.Graphics;
using RayTracing.Maths;

namespace RayTracing.Materials
{
    public class Emissive: IMaterial
    {
        private ITexture _emit;

        public Emissive(ITexture emit)
        {
            _emit = emit;
        }
        public Emissive(Color emitColor)
        {
            _emit = new SolidColor(emitColor);
        }
        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            attenuation = Color.FromColor4(Color4.Black);
            scattered = new Ray();
            return false;
        }
        
        public Color Emitted(ref double u, ref double v, ref Vector3 p)
        {
            return _emit[u, v];
        }
    }
}