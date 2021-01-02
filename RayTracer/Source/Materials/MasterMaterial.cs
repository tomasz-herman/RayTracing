using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Materials
{
    public class MasterMaterial : IMaterial
    {
        private const int SAMPLES = 10000;
        
        private readonly IMaterial[] _materials;
        public Emissive Emissive => (Emissive) _materials[1];
        public Diffuse Diffuse => (Diffuse) _materials[2];
        public Reflective Reflective => (Reflective) _materials[3];
        public Refractive Refractive => (Refractive) _materials[4];

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

        public MasterMaterial(AbstractSampler<int> sampler = null)
        {
            _materials = new IMaterial[]
            {
                new Emissive(new Color()), //DummyColor, used when all probabilities are 0, ~black body
                new Emissive(new Color()),
                new Diffuse(new Color()),
                new Reflective(new Color()),
                new Refractive(new Color(), 1)
            };
            _sampler = sampler ?? NewSampler();
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
    }
}