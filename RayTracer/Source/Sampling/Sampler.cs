using System;
using System.Collections.Generic;

namespace RayTracing.Sampling
{
    public class Sampler<T> : AbstractSampler<T>
    {
        private Random random = new Random();
        private int current;
        private int set;

        public Sampler(Func<int, List<T>> generator, int count = 64, int sets = 1, Func<T, T> mapper = null)
            : base(generator, count, sets, mapper)
        {
        }

        public override T GetSample()
        {
            if (current >= count)
            {
                current = 0;
                if (Sets > 1) set = random.Next(Sets);
            }

            return Samples[set][current++];
        }

        public override T GetSample(int i)
        {
            return Samples[set][i];
        }
    }
}