using System;
using System.Collections.Generic;
using System.Linq;

namespace RayTracing.Sampling
{
    public static class IntSampling
    {
        private static readonly Random _random = new Random();

        public static List<int> Distribution(int count, params float[] probabilities)
        {
            if (probabilities.Length == 0)
                throw new ArgumentException("Zero lenght probabilities array");
            if(probabilities.Any(probability => probability < 0)) 
                throw new ArgumentException("Probability lesser than zero.");

            float sum = probabilities.Sum();

            if(sum == 0)
            {
                Log.Warn("Probabilities sum to 0 returning list containing zeroes");
                return Enumerable.Repeat(0, count).ToList();
            }

            List<int> samples = new List<int>();
            
            for (int i = 0; i < count; i++)
            {
                float next = (float)_random.NextDouble() * sum;
                float counter = 0;
                for (int j = 0; j < probabilities.Length; j++)
                {
                    counter += probabilities[j];
                    if (counter >= next)
                    {
                        samples.Add(j + 1);
                        break;
                    }
                }
            }

            return samples;
        }
    }
}