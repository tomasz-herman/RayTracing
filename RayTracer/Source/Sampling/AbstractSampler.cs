using System;
using System.Collections.Generic;

namespace RayTracing.Sampling
{
    public abstract class AbstractSampler<T>
    {
        protected readonly List<List<T>> Samples = new List<List<T>>();
        protected readonly int count;
        protected readonly int Sets;

        public AbstractSampler(Func<int, List<T>> generator, int count = 64, int sets = 1, Func<T, T> mapper = null)
        {
            this.count = count;
            this.Sets = sets;
            mapper ??= T => T;
            for (int i = 0; i < sets; i++)
            {
                Samples.Add(generator(count));
                for (int j = 0; j < count; j++)
                {
                    Samples[i][j] = mapper(Samples[i][j]);
                }
            }
        }

        public abstract T GetSample();

        public abstract T GetSample(int i);

        public int Count => count;

        public T Sample => GetSample();
    }
}