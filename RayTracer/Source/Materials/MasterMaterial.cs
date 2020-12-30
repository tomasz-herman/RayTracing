using System;
using System.Collections.Generic;
using System.Linq;
using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Materials
{
    public class MasterMaterial : IMaterial
    {
        public Emissive Emissive { get; set; }
        public Diffuse Diffuse { get; set; }
        public Reflective Reflective { get; set; }
        public Refractive Refractive { get; set; }
        public int EmissivePart { get; set; }
        public int DiffusePart { get; set; }
        public int ReflectivePart { get; set; }
        public int RefractivePart { get; set; }
        private readonly AbstractSampler<float> _sampler;

        public MasterMaterial(AbstractSampler<float> sampler = null)
        {
            _sampler = sampler ?? new ThreadSafeSampler<float>(FloatSampling.Random, 10000);
        }
        
        private IMaterial GetMaterial()
        {
            var probabilities = new List<int>(4);
            var materials = new List<IMaterial>(4);
            if (Emissive != null)
            {
                probabilities.Add(EmissivePart);
                materials.Add(Emissive);
            }
            if (Diffuse != null)
            {
                probabilities.Add(DiffusePart);
                materials.Add(Diffuse);
            }
            if (Reflective != null)
            {
                probabilities.Add(ReflectivePart);
                materials.Add(Reflective);
            }
            if (Refractive != null)
            {
                probabilities.Add(RefractivePart);
                materials.Add(Refractive);
            }
            
            float rand = _sampler.GetSample();
            int sum = probabilities.Sum();
            int seek = (int) (rand * sum) + 1;
            int sought = 0;
            for (int i = 0; i < probabilities.Count; i++)
            {
                if (sought < seek && seek <= sought + probabilities[i])
                    return materials[i];

                sought += probabilities[i];
            }

            throw new Exception("material not found");
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            var material = GetMaterial();
            return material.Scatter(ref ray, ref hit, out attenuation, out scattered);
        }
    }
}