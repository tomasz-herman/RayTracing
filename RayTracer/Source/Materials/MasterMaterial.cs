using Newtonsoft.Json;
using RayTracing.Maths;
using RayTracing.Sampling;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    public class MasterMaterial : IMaterial
    {
        private const int SAMPLES = 10000;

        private readonly IMaterial[] _materials;

        public Emissive Emissive
        {
            get => (Emissive) _materials[1];
            set => _materials[1] = value;
        }

        public Diffuse Diffuse
        {
            get => (Diffuse) _materials[2];
            set => _materials[2] = value;
        }

        public Reflective Reflective
        {
            get => (Reflective) _materials[3];
            set => _materials[3] = value;
        }

        public Refractive Refractive
        {
            get => (Refractive) _materials[4];
            set => _materials[4] = value;
        }

        [JsonIgnore] public Color AverageColor => Emissive.AverageColor;

        public (float emissive, float diffuse, float reflective, float refractive) Parts
        {
            get => _parts;
            set
            {
                _parts = value;
                _sampler = NewSampler();
            }
        }

        private AbstractSampler<int> _sampler;
        private (float emissive, float diffuse, float reflective, float refractive) _parts;

        public MasterMaterial(params IMaterial[] materials)
        {
            _materials = new IMaterial[]
            {
                new Emissive(new Color()), //DummyColor, used when all probabilities are 0, ~black body
                new Emissive(new Color()),
                new Diffuse(new Color()),
                new Reflective(new Color()),
                new Refractive(new Color(), 1)
            };

            if (materials != null)
                foreach (var material in materials)
                {
                    switch (material)
                    {
                        case Emissive mat:
                            Emissive = mat;
                            _parts.emissive = 1;
                            break;
                        case Diffuse mat:
                            Diffuse = mat;
                            _parts.diffuse = 1;
                            break;
                        case Reflective mat:
                            Reflective = mat;
                            _parts.reflective = 1;
                            break;
                        case Refractive mat:
                            Refractive = mat;
                            _parts.refractive = 1;
                            break;
                    }
                }

            _sampler = NewSampler();
        }

        private ThreadSafeSampler<int> NewSampler()
        {
            return new ThreadSafeSampler<int>(count => IntSampling.Distribution(count,
                _parts.emissive,
                _parts.diffuse,
                _parts.reflective,
                _parts.refractive), SAMPLES);
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            return _materials[_sampler.Sample].Scatter(ref ray, ref hit, out attenuation, out scattered);
        }

        public Color Emitted(float u, float v)
        {
            return _materials[_sampler.Sample].Emitted(u, v);
        }

        public void Use(Shader shader, float part)
        {
            var sum = Parts.diffuse + Parts.emissive + Parts.reflective + Parts.refractive;
            if (sum == 0) sum = 1;
            Emissive.Use(shader, Parts.emissive / sum);
            Diffuse.Use(shader, Parts.diffuse / sum);
            Reflective.Use(shader, Parts.reflective / sum);
        }
    }
}