using System;
using System.Collections.Generic;
using System.Threading;

namespace RayTracing.Sampling
{
    public class ThreadSafeSampler<T> : AbstractSampler<T>
    {
        private ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Thread.CurrentThread.ManagedThreadId));
        private ThreadLocal<int> current = new ThreadLocal<int>(() => 0);
        private ThreadLocal<int> set = new ThreadLocal<int>(() => 0);
        
        public ThreadSafeSampler(Func<int, List<T>> generator, int count = 64, int sets = 1, Func<T, T> mapper = null) 
            : base(generator, count, sets, mapper) { }

        public override T GetSample()
        {
            if(current.Value >= count) 
            {
                current.Value = 0;
                if(sets > 1) set.Value = random.Value.Next(sets);
            }
            return samples[set.Value][current.Value++];
        }
        
        public override T GetSample(int i)
        {
            return samples[set.Value][i];
        }
    }
}