using OpenTK.Graphics;
using RayTracing.Maths;

namespace RayTracing.Materials
{
    public interface ITexture
    {
        public Color this[float x,float y] { get; }
    }
}