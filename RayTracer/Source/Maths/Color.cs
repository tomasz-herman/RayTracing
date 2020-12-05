using System;
using System.Collections.Generic;
using OpenTK.Graphics;

namespace RayTracing.Maths
{
    public struct Color
    {
        public float R, G, B;
        public IEnumerable<byte> Components() => new[] { RComp, GComp, BComp };
        public byte RComp => (byte) (R * 255);
        public byte GComp => (byte) (G * 255);
        public byte BComp => (byte) (B * 255);

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
        
        public static Color operator /(Color first, float scalar)
        {
            first.R /= scalar;
            first.G /= scalar;
            first.B /= scalar;
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

        public Color GammaCorrection(float gamma)
        {
            float exp = 1.0f / gamma;
            R = (float) Math.Pow(R, exp);
            G = (float) Math.Pow(G, exp);
            B = (float) Math.Pow(B, exp);
            return this;
        }
    }
}