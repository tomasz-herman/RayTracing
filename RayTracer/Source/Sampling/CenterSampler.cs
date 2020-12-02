using System;
using OpenTK;

namespace RayTracer.Sampling
{
    public class CenterSampler : ISampler
    {
        private readonly Vector2 sample = new Vector2(0.5f, 0.5f);

        public Vector2 Sample()
        {
            return sample;
        }

        public Vector2 Sample(int num)
        {
            if (num == 0)
                return sample;
            else
                throw new ArgumentException("Sample number should be equal to 0");
        }
    }
}