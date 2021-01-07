using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace RayTracing.Sampling
{
    public static class Vec2Sampling
    {
        private static readonly Random _random = new Random();

        public static List<Vector2> Dummy(int count)
        {
            List<Vector2> samples = new List<Vector2>();
            for (int i = 0; i < count; ++i)
            {
                samples.Add(new Vector2(0.5f, 0.5f));
            }

            return samples;
        }

        public static List<Vector2> Regular(int count)
        {
            int size = (int) Math.Ceiling(Math.Sqrt(count));
            List<Vector2> samples = new List<Vector2>();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Vector2 sample = new Vector2(
                        (i + 0.5f) / size,
                        (j + 0.5f) / size
                    );
                    samples.Add(sample);
                }
            }

            samples = samples.OrderBy(item => _random.Next()).Take(count).ToList();

            return samples;
        }

        public static List<Vector2> Jittered(int count)
        {
            int size = (int) Math.Ceiling(Math.Sqrt(count));
            List<Vector2> samples = new List<Vector2>();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Vector2 sample = new Vector2(
                        (i + (float) _random.NextDouble()) / size,
                        (j + (float) _random.NextDouble()) / size
                    );
                    samples.Add(sample);
                }
            }

            samples = samples.OrderBy(item => _random.Next()).Take(count).ToList();

            return samples;
        }

        public static List<Vector2> Random(int count)
        {
            List<Vector2> samples = new List<Vector2>();
            for (int i = 0; i < count; ++i)
            {
                samples.Add(new Vector2(
                    (float) _random.NextDouble(),
                    (float) _random.NextDouble())
                );
            }

            return samples;
        }

        public static Vector2 WiderRange(Vector2 sample)
        {
            return new Vector2(sample.X * 2 - 1, sample.Y * 2 - 1);
        }

        public static Vector2 ToDisk(Vector2 sample)
        {
            sample = WiderRange(sample);
            float r, phi;
            if (sample.X > -sample.Y)
            {
                if (sample.X > sample.Y)
                {
                    r = sample.X;
                    phi = sample.Y / sample.X;
                }
                else
                {
                    r = sample.Y;
                    phi = 2 - sample.X / sample.Y;
                }
            }
            else
            {
                if (sample.X < sample.Y)
                {
                    r = -sample.X;
                    phi = 4 + sample.Y / sample.X;
                }
                else
                {
                    r = -sample.Y;
                    phi = 6 - sample.X / sample.Y;
                }
            }

            if (sample.X == 0 && sample.Y == 0)
            {
                phi = 0;
            }

            phi *= (float) Math.PI / 4;
            return new Vector2(r * (float) Math.Cos(phi), r * (float) Math.Sin(phi));
        }
    }
}