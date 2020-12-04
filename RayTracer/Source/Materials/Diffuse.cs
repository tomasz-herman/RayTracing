using System;
using OpenTK;
using RayTracer.Maths;

namespace RayTracer.Materials
{
    public class Diffuse : IMaterial
    {
        public Color Albedo;

        public Diffuse(Color albedo)
        {
            Albedo = albedo;
        }
        
        public bool Scatter(ref Ray ray, ref HitInfo hit, out Color attenuation, out Ray scattered)
        {
            scattered = new Ray(hit.HitPoint, hit.Normal + RandomVector3());
            attenuation = Albedo;
            return true;

            static Vector3 RandomVector3()
            {
                Random rand = new Random();
                Vector3 vec = new Vector3();
                
                do
                {
                    vec.X = (float) rand.NextDouble();
                    vec.Y = (float) rand.NextDouble();
                    vec.Z = (float) rand.NextDouble();
                } while (vec.LengthSquared > 1);

                return vec;
            }
        }
    }
}