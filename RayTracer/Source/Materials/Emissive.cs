using System;
using OpenTK;
using OpenTK.Graphics;
using RayTracing.Maths;
using RayTracing.Sampling;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public class Emissive : IMaterial
    {
        public Color AverageColor => _averageColor;

        private ITexture _emit;
        private Color _averageColor;
        
        public Emissive(ITexture emit)
        {
            _emit = emit;
            int samples = 10000;
            var sampler = new ThreadSafeSampler<Vector2>(Vec2Sampling.Random, samples);
            for (int i = 0; i < samples; i++)
            {
                var coords = sampler.GetSample();
                _averageColor += _emit[coords.X, coords.Y];
            }

            _averageColor /= samples;
        }

        public Emissive(Color emitColor)
        {
            _emit = new SolidColor(emitColor);
            _averageColor = emitColor;
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            attenuation = Color.FromColor4(Color4.Black);
            scattered = new Ray();
            return false;
        }

        public Color Emitted(float u, float v)
        {
            return _emit[u, v];
        }

        public void Use(Shader shader)
        {
            _emit.Use(shader);
        }
    }
}