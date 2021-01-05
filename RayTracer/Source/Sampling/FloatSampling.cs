using System;
using System.Collections.Generic;

namespace RayTracing.Sampling
{
    public static class FloatSampling
    {
        private static readonly Random _random = new Random();

        public static List<float> Random(int count)
        {
            List<float> samples = new List<float>();
            for (int i = 0; i < count; ++i)
            {
                samples.Add((float) _random.NextDouble());
            }

            return samples;
        }
    }
}