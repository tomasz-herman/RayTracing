using System;
using OpenTK;
using RayTracing.Maths;
using RayTracing.Sampling;
using RayTracing.Shaders;

namespace RayTracing.Materials
{
    // https://raytracing.github.io/books/RayTracingInOneWeekend.html#dielectrics
    public class Refractive : IMaterial
    {
        public ITexture Albedo { get; set; }
        public float RefractiveIndex { get; set; }
        private readonly AbstractSampler<float> _sampler;

        public Refractive(Color albedo, float refractiveIndex, AbstractSampler<float> sampler = null)
        {
            Albedo = new SolidColor(albedo);
            RefractiveIndex = refractiveIndex;
            _sampler = sampler ?? new ThreadSafeSampler<float>(FloatSampling.Random, 10000);
        }
        
        public Refractive(ITexture albedo, float refractiveIndex, AbstractSampler<float> sampler = null)
        {
            Albedo = albedo;
            RefractiveIndex = refractiveIndex;
            _sampler = sampler ?? new ThreadSafeSampler<float>(FloatSampling.Random, 10000);
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            attenuation = Albedo[hit.TexCoord.X, hit.TexCoord.Y];
            double refractionRatio = hit.FrontFace ? (1.0 / RefractiveIndex) : RefractiveIndex;
            Vector3 unitDirection = ray.Direction.Normalized();

            double cosTheta = Math.Min(Vector3.Dot(-unitDirection, hit.Normal), 1.0);
            double sinTheta = Math.Sqrt(1.0 - cosTheta * cosTheta);

            bool cannotRefract = refractionRatio * sinTheta > 1.0;
            Vector3 direction;

            if (cannotRefract || Reflectance(cosTheta, refractionRatio) > _sampler.GetSample())
            {
                direction = ray.Direction.Normalized().Reflect(hit.Normal);
            }
            else
            {
                direction = Refract(unitDirection, hit.Normal, refractionRatio);
            }

            scattered = new Ray(hit.HitPoint, direction);
            return true;
        }

        static double Reflectance(double cosine, double refIdx)
        {
            var r0 = (1 - refIdx) / (1 + refIdx);
            r0 *= r0;
            return r0 + (1 - r0) * Math.Pow(1 - cosine, 5);
        }

        Vector3 Refract(Vector3 uv, Vector3 n, double etaiOverEtat)
        {
            var cosTheta = (float) Math.Min(Vector3.Dot(-uv, n), 1.0);
            Vector3 rOutPerp = (float) etaiOverEtat * (uv + cosTheta * n);
            Vector3 rOutParallel = -(float) Math.Sqrt(Math.Abs(1.0 - rOutPerp.LengthSquared)) * n;
            return rOutPerp + rOutParallel;
        }
        
        public void Use(Shader shader, float part)
        {
            
        }
    }
}