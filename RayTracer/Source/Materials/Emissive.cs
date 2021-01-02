using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using RayTracing.Maths;
using RayTracing.Sampling;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public class Emissive : IMaterial
    {
        public Color AverageColor => _averageColor;

        public ITexture Emit { get; set; }
        private Color _averageColor;
        
        public Emissive(ITexture emit)
        {
            Emit = emit;
            int samples = 10000;
            var sampler = new ThreadSafeSampler<Vector2>(Vec2Sampling.Random, samples);
            for (int i = 0; i < samples; i++)
            {
                var coords = sampler.GetSample();
                _averageColor += Emit[coords.X, coords.Y];
            }

            _averageColor /= samples;
        }

        public Emissive(Color emitColor)
        {
            Emit = new SolidColor(emitColor);
            _averageColor = emitColor;
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            attenuation = Color.FromColor4(Color4.Black);
            scattered = new Ray();
            return false;
        }

        public Color Emitted(float u, float v, ref Vector3 p)
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