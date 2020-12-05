using System;
using OpenTK;
using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Materials
{
    public class Diffuse : IMaterial
    {
        public Color Albedo;
        private AbstractSampler<Vector3> sampler;

        public Diffuse(Color albedo, AbstractSampler<Vector3> sampler = null)
        {
            this.sampler = sampler ?? new Sampler<Vector3>(Vec3Sampling.UniformSphere, 125, 8);
            Albedo = albedo;
        }
        
        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            scattered = new Ray(hit.HitPoint, hit.Normal + sampler.Sample);
            attenuation = Albedo;
            return true;
        }
    }
}