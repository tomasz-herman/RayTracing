using System;
using System.Collections.Generic;
using System.Linq;
using RayTracing.Maths;
using RayTracing.Sampling;

namespace RayTracing.Materials
{
    public class MasterMaterial : IMaterial
    {
        private readonly List<IMaterial> _materials;
        private readonly List<int> _probabilities;
        private readonly AbstractSampler<float> _sampler;

        public MasterMaterial(List<IMaterial> materials, List<int> probabilities, AbstractSampler<float> sampler = null)
        {
            if (probabilities.Count != materials.Count)
                throw new ArgumentException("probabilities size != materials size");
            if (probabilities.Exists(x => x < 0))
                throw new ArgumentException("probability < 0");

            _materials = materials;
            _probabilities = probabilities;
            _sampler = sampler ?? new ThreadSafeSampler<float>(FloatSampling.Random, 10000);
        }

        public MasterMaterial()
        {
            _materials = new List<IMaterial>();
            _probabilities = new List<int>();
            _sampler = new ThreadSafeSampler<float>(FloatSampling.Random, 10000);
        }

        public void AddMaterial(IMaterial material, int probability)
        {
            _materials.Add(material);
            _probabilities.Add(probability);
        }

        private int GetMaterialIndex()
        {
            float rand = _sampler.GetSample();
            int sum = _probabilities.Sum();
            int seek = (int) (rand * sum) + 1;
            int sought = 0;
            for (int i = 0; i < _probabilities.Count; i++)
            {
                if (sought < seek && seek <= sought + _probabilities[i])
                    return i;

                sought += _probabilities[i];
            }

            return -1;
        }

        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            var index = GetMaterialIndex();
            var material = _materials[index];
            return material.Scatter(ref ray, ref hit, out attenuation, out scattered);
        }
    }
}