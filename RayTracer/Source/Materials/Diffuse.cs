using OpenTK;
using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Materials
{
    public class Diffuse : IMaterial
    {
        public ITexture Albedo { get; set; }
        private readonly AbstractSampler<Vector3> _sampler;

        public Diffuse(ITexture albedo, AbstractSampler<Vector3> sampler = null)
        {
            _sampler = sampler ?? new ThreadSafeSampler<Vector3>(Vec3Sampling.UniformSphere, 10000, 8, Vec3Sampling.ToSphereSurface);
            Albedo = albedo;
        }
        
        public Diffuse(Color albedo, AbstractSampler<Vector3> sampler = null)
        {
            _sampler = sampler ?? new ThreadSafeSampler<Vector3>(Vec3Sampling.UniformSphere, 10000, 8, Vec3Sampling.ToSphereSurface);
            Albedo = new SolidColor(albedo);
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            scattered = new Ray(hit.HitPoint, hit.Normal + _sampler.Sample);
            attenuation = Albedo[hit.TexCoord.X,hit.TexCoord.Y];
            return true;
        }
    }
}