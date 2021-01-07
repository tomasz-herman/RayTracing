using System;
using System.Collections.Generic;
using System.Threading;

namespace RayTracing.Sampling
{
    public class ThreadSafeSampler<T> : AbstractSampler<T>
    {
        private ThreadLocal<Random> _random =
            new ThreadLocal<Random>(() => new Random(Thread.CurrentThread.ManagedThreadId));

        private ThreadLocal<int> _current = new ThreadLocal<int>(() => 0);
        private ThreadLocal<int> _set = new ThreadLocal<int>(() => 0);

        public ThreadSafeSampler(Func<int, List<T>> generator, int count = 64, int sets = 1, Func<T, T> mapper = null)
            : base(generator, count, sets, mapper)
        {
        }

        public override T GetSample()
        {
            if (_current.Value >= count)
            {
                _current.Value = 0;
                if (Sets > 1) _set.Value = _random.Value.Next(Sets);
            }

            return Samples[_set.Value][_current.Value++];
        }

        public override T GetSample(int i)
        {
            return Samples[_set.Value][i];
        }
    }
}