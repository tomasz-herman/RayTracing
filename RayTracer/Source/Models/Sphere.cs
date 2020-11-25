using System;
using System.Collections.Generic;
using OpenTK;
using RayTracer.Maths;

namespace RayTracer.Models
{
    public class Sphere : Model
    {
        private Mesh mesh;

        public Sphere()
        {
            var (positions, texCoords) = GetVertexList(100, 100);
            var indicesList = GetElementBuffer(100, 100);
            mesh = new Mesh(positions,positions, texCoords, indicesList);
        }

        public override HitInfo HitTest(Ray ray, HitInfo hitInfo)
        {
            double t;
            Vector3 distance = ray.Origin - Position;

            double a = ray.Direction.LengthSquared;
            double b = Vector3.Dot(distance * 2, ray.Direction);
            double c = distance.LengthSquared - Scale * Scale;
            double disc = b * b - 4 * a * c;

            if (disc < 0)
                return new HitInfo {Distance = Double.MaxValue};
            double discSq = Math.Sqrt(disc);
            double denom = 2 * a;
            t = (-b - discSq) / denom;
            if (t < Ray.Epsilon)
            {
                t = (-b + discSq) / denom;
            }

            if (t < Ray.Epsilon)
                return new HitInfo {Distance = Double.MaxValue};

            return new HitInfo {Distance = t};
        }

        public override Mesh GetMesh()
        {
            return mesh;
        }


        private (List<float>, List<float>) GetVertexList(short rings, short sectors)
        {
            float R = 1f / (rings - 1);
            float S = 1f / (sectors - 1);
            short r, s;
            float x, y, z;

            List<float> positions = new List<float>(rings * sectors * 3);
            List<float> texCoords = new List<float>(rings * sectors * 2);

            for (r = 0; r < rings; r++)
            {
                for (s = 0; s < sectors; s++)
                {
                    x = (float) (Math.Cos(2 * (float) Math.PI * s * S) * Math.Sin((float) Math.PI * r * R));
                    y = (float) (Math.Sin(-(float) Math.PI / 2 + (float) Math.PI * r * R));
                    z = (float) (Math.Sin(2 * (float) Math.PI * s * S) * Math.Sin((float) Math.PI * r * R));
                    // positions
                    positions.Add(x);
                    positions.Add(y);
                    positions.Add(z);
                    // texture coordinates
                    texCoords.Add(1 - s * S);
                    texCoords.Add(r * R);
                }
            }

            return (positions, texCoords);
        }

        private List<int> GetElementBuffer(short rings, short sectors)
        {
            short r, s;

            List<int> elementBuffer = new List<int>(rings * sectors * 6);

            for (r = 0; r < rings - 1; r++)
            {
                for (s = 0; s < sectors - 1; s++)
                {
                    elementBuffer.Add((r * sectors + s));
                    elementBuffer.Add((r * sectors + (s + 1)));
                    elementBuffer.Add(((r + 1) * sectors + (s + 1)));
                    elementBuffer.Add(((r + 1) * sectors + (s + 1)));
                    elementBuffer.Add((r * sectors + s));
                    elementBuffer.Add(((r + 1) * sectors + s));
                }
            }
            
            return elementBuffer;
        }
    }
}