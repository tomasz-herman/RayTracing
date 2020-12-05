using System;
using System.Collections.Generic;
using OpenTK;

namespace RayTracing.Sampling
{
    public class Sampler<T>
    {
        private Random random = new Random();
        private List<List<T>> samples = new List<List<T>>();
        private int count, current, sets, set;
        
        public Sampler(Func<int, List<T>> generator, int count = 64, int sets = 1, Func<T, T> mapper = null)
        {
            this.count = count;
            this.sets = sets;
            mapper ??= T => T;
            for (int i = 0; i < sets; i++)
            {
                samples.Add(generator(count));
                for (int j = 0; j < count; j++)
                {
                    samples[i][j] = mapper(samples[i][j]);
                }
            }
        }

        public T GetSample()
        {
            if(current >= count) 
            {
                current = 0;
                if(sets > 1) set = random.Next(sets);
            }
            return samples[set][current++];
        }
        
        public T GetSample(int i)
        {
            return samples[set][i];
        }

        public int Count => count;
        
        public T Sample => GetSample();
    }
}