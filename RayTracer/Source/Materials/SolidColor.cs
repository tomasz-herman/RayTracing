﻿using RayTracing.Maths;

namespace RayTracing.Materials
{
    public class SolidColor:ITexture
    {
        public Color Color;

        public SolidColor(Color color)
        {
            Color = color;
        }
        public Color this[float x, float y] => Color;
    }
}