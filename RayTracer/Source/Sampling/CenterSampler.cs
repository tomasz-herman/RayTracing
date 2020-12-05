using System;
using OpenTK;

namespace RayTracing.Sampling
{
    public class CenterSampler : ISampler
    {
        private readonly Vector2 _sample = new Vector2(0.5f, 0.5f);

        public Vector2 Sample()
        {
            return _sample;
        }

        public Vector2 Sample(int num)
        {
            if (num == 0)
                return _sample;
            else
                throw new ArgumentException("Sample number should be equal to 0");
        }
    }
}