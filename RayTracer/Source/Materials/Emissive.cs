using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using RayTracing.Maths;
using RayTracing.Sampling;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public class Emissive : IMaterial
    {
        private const int SAMPLES = 10000;
        private ITexture _albedo;

        [JsonIgnore] public Color AverageColor => _averageColor;
        public float Amplification { get; set; } = 1;

        public ITexture Albedo
        {
            get => _albedo;
            set
            {
                _albedo = value;
                UpdateAverageColor(value);
            }
        }

        private Color _averageColor;

        [JsonConstructor]
        public Emissive(ITexture albedo, float amp = 1)
        {
            Amplification = amp;
            Albedo = albedo;
        }

        public Emissive(Color emitColor, float amp = 1)
        {
            Amplification = amp;
            Albedo = new SolidColor(emitColor);
        }

        private void UpdateAverageColor(ITexture texture)
        {
            var sampler = new ThreadSafeSampler<Vector2>(Vec2Sampling.Random, SAMPLES);
            for (int i = 0; i < SAMPLES; i++)
            {
                var coords = sampler.GetSample();
                _averageColor += texture[coords.X, coords.Y];
            }

            _averageColor /= SAMPLES;
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            attenuation = Color.FromColor4(Color4.Black);
            scattered = new Ray();
            return false;
        }

        public Color Emitted(float u, float v)
        {
            return Albedo[u, v] * Amplification;
        }

        public void Use(Shader shader, float part)
        {
            Albedo.Use(shader, 0, part);
        }
    }
}