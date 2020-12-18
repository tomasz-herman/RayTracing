using OpenTK.Graphics;
using RayTracing.Maths;

namespace RayTracing.Materials
{
    public interface ITexture
    {
        public Color this[double x,double y] { get; }
    }
}