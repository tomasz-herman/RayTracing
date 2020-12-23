using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Materials
{
    // https://raytracing.github.io/books/RayTracingInOneWeekend.html#dielectrics
    public class Refractive : IMaterial
    {
        private readonly double _ir;
        public Refractive(double ir)
        {
            _ir = ir;
        }

        private readonly Random _random = new Random();
        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            attenuation = new Color(1f, 1f, 1f);
            double refractionRatio = hit.FrontFace ? (1.0 / _ir) : _ir;
            Vector3 unitDirection = ray.Direction.Normalized();
            
            double cosTheta = Math.Min(Vector3.Dot(-unitDirection, hit.Normal), 1.0);
            double sinTheta = Math.Sqrt(1.0 - cosTheta*cosTheta);

            bool cannotRefract = refractionRatio * sinTheta > 1.0;
            Vector3 direction;

            if (cannotRefract || Reflectance(cosTheta, refractionRatio) > _random.NextDouble())
            {
                direction = ray.Direction.Normalized().Reflect(hit.Normal);
            }
            else
            {
                direction = refract(unitDirection, hit.Normal, refractionRatio);
            }

            scattered = new Ray(hit.HitPoint, direction);
            return true;
        }
        
        static double Reflectance(double cosine, double refIdx) {
            var r0 = (1-refIdx) / (1+refIdx);
            r0 *= r0;
            return r0 + (1-r0)*Math.Pow(1 - cosine,5);
        }
        
        Vector3 refract(Vector3 uv, Vector3 n, double etaiOverEtat) {
            var cosTheta = (float)Math.Min(Vector3.Dot(-uv, n), 1.0);
            Vector3 rOutPerp =  (float)etaiOverEtat * (uv + cosTheta*n);
            Vector3 rOutParallel = -(float)Math.Sqrt(Math.Abs(1.0 - rOutPerp.LengthSquared)) * n;
            return rOutPerp + rOutParallel;
        }
    }
}