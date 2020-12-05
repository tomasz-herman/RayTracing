using System;
using System.Collections.Generic;
using System.Threading;

namespace RayTracing.Sampling
{
    public abstract class AbstractSampler<T>
    {
        protected List<List<T>> samples = new List<List<T>>();
        protected int count, sets;
        
        public AbstractSampler(Func<int, List<T>> generator, int count = 64, int sets = 1, Func<T, T> mapper = null)
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

        public abstract T GetSample();

        public abstract T GetSample(int i);

        public int Count => count;
        
        public T Sample => GetSample();
    }
}