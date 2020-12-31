using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Materials
{
    public class MasterMaterial : IMaterial
    {
        private const int SAMPLES = 10000;
        
        private IMaterial[] Materials;
        public Emissive Emissive => (Emissive) Materials[1];
        public Diffuse Diffuse => (Diffuse) Materials[2];
        public Reflective Reflective => (Reflective) Materials[3];
        public Refractive Refractive => (Refractive) Materials[4];

        public (float emissive, float diffuse, float reflective, float refractive) Parts
        {
            get => parts;
            set
            {
                parts = value;
                _sampler = NewSampler();
            }
        }

        private AbstractSampler<int> _sampler;
        private (float emissive, float diffuse, float reflective, float refractive) parts;

        public MasterMaterial(AbstractSampler<int> sampler = null)
        {
            Materials = new IMaterial[]
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
                parts.emissive, 
                parts.diffuse, 
                parts.reflective,
                parts.refractive), SAMPLES);
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            return Materials[_sampler.Sample].Scatter(ref ray, ref hit, out attenuation, out scattered);
        }
    }
}