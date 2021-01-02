using System;
using System.Collections.Generic;
using Assimp;
using OpenTK;
using OpenTK.Graphics;

namespace RayTracing.Maths
{
    public struct Color
    {
        public float R, G, B;
        public IEnumerable<byte> Components() => new[] {RComp, GComp, BComp};
        public byte RComp => (byte) (R * 255);
        public byte GComp => (byte) (G * 255);
        public byte BComp => (byte) (B * 255);

        private const float MinVal = 0f;
        private const float MaxVal = 1f;

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
        
        public static Color FromAssimpColor4(Color4D color4)
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

        public Vector3 ToVector3()
        {
            return new Vector3(R, G, B);
        }

        // from C++ codebase, and previously from JavaFX sources, now in c# code
        public (float hue, float saturation, float brightness) ToHsb() {
            float hue, saturation, brightness;
            float cmax = (R > G) ? R : G;
            if (B > cmax) cmax = B;
            float cmin = (R < G) ? R : G;
            if (B < cmin) cmin = B;

            brightness = cmax;
            if (cmax != 0)
                saturation = (cmax - cmin) / cmax;
            else
                saturation = 0;

            if (saturation == 0)
            {
                hue = 0;
            }
            else
            {
                float redc = (cmax - R) / (cmax - cmin);
                float greenc = (cmax - G) / (cmax - cmin);
                float bluec = (cmax - B) / (cmax - cmin);
                if (R == cmax)
                    hue = bluec - greenc;
                else if (G == cmax)
                    hue = 2.0f + redc - bluec;
                else
                    hue = 4.0f + greenc - redc;
                hue = hue / 6.0f;
                if (hue < 0)
                    hue = hue + 1.0f;
            }
            return (hue * 360, saturation, brightness);
        }

        public float GetHue()
        {
            return ToHsb().hue;
        }

        public float GetSaturation()
        {
            return ToHsb().saturation;
        }

        public float GetBrightness()
        {
            float cmax = (R > G) ? R : G;
            if (B > cmax) cmax = B;
            return cmax;
        }
    }
}