using OpenTK.Graphics;

namespace RayTracer.Maths
{
    public struct Color
    {
        public float R, G, B;

        public static Color FromColor4(Color4 color4)
        {
            return new Color
            {
                R = color4.R,
                G = color4.G,
                B = color4.B
            };
        }
        //TODO: operatory  +- /* przez skalar, mieszanie
    }
}