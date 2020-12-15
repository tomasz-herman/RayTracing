using OpenTK;
using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Materials
{
    public class Reflective : IMaterial
    {
        public Color Albedo { get; set; }
        public float Disturbance { get; set; }
        private readonly AbstractSampler<Vector3> _sampler;

        public Reflective(Color albedo, float disturbance = 0, AbstractSampler<Vector3> sampler = null)
        {
            _sampler = sampler ?? new ThreadSafeSampler<Vector3>(Vec3Sampling.UniformSphere, 125, 8);
            Albedo = albedo;
            Disturbance = disturbance;
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            Vector3 reflected = ray.Direction.Reflect(hit.Normal);
            scattered = new Ray(hit.HitPoint, reflected + Disturbance * _sampler.Sample);
            attenuation = Albedo;
            return Vector3.Dot(scattered.Direction, hit.Normal) > 0;
        }
    }
}