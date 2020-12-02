using System;
using OpenTK.Graphics;

namespace RayTracer.Maths
{
    public struct Color
    {
        public float R, G, B;
        public Color(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
        
        public static Color FromColor4(Color4 color4)
        {
            return new Color
            {
                R = color4.R,
                G = color4.G,
                B = color4.B
            };
        }

        public static Color operator +(Color first, Color second)
        {
            first.R += second.R;
            first.G += second.G;
            first.B += second.B;
            return first;
        }

        public static Color operator *(Color first, Color second)
        {
            first.R *= second.R;
            first.G *= second.G;
            first.B *= second.B;
            return first;
        }

        public static Color operator *(Color first, float scalar)
        {
            first.R *= scalar;
            first.G *= scalar;
            first.B *= scalar;
            return first;
        }

        public static Color Mix(Color first, Color second, float firstShare)
        {
            return first * firstShare + second * (1 - firstShare);
        }

        private const float MinVal = 0f;
        private const float MaxVal = 1f;

        public Color Clamp()
        {
            R = Math.Clamp(R, MinVal, MaxVal);
            G = Math.Clamp(G, MinVal, MaxVal);
            B = Math.Clamp(B, MinVal, MaxVal);
            return this;
        }
    }
}