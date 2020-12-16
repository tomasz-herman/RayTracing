using System;
using System.Collections.Generic;
using OpenTK;

namespace RayTracing.Sampling
{
    public static class Vec3Sampling
    {
        private static readonly Random Random = new Random();
        
        public static List<Vector3> UniformSphere(int count) {
            List<Vector3> samples = new List<Vector3>();
            for (int i = 0; i < count; ++i) {
                Vector3 sample = new Vector3();
                do
                {
                    sample.X = (float) Random.NextDouble() * 2 - 1;
                    sample.Y = (float) Random.NextDouble() * 2 - 1;
                    sample.Z = (float) Random.NextDouble() * 2 - 1;
                } while (sample.LengthSquared > 1);
                samples.Add(sample);
            }
            return samples;
        }
    }
}