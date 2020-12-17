using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Sphere : Model
    {
        private protected override void LoadInternal()
        {
            var (positions, texCoords) = GetVertexList(100, 100);
            var indicesList = GetIndices(100, 100);
            Mesh = new Mesh(positions, positions, texCoords, indicesList);
            Mesh.Load();
        }

        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            Vector3 distance = ray.Origin - Position;

            float a = ray.Direction.LengthSquared;
            float bHalf = Vector3.Dot(distance, ray.Direction);
            float c = distance.LengthSquared - Scale * Scale;
            float disc = bHalf * bHalf - a * c;

            if (disc < 0)
            {
                return false;
            }

            float discSq = (float) Math.Sqrt(disc);

            float root = (-bHalf - discSq) / a;
            if (root < from || to < root)
            {
                root = (-bHalf + discSq) / a;
                if (root < from || to < root)
                    return false;
            }

            hit.Distance = root;
            hit.HitPoint = ray.Origin + ray.Direction * hit.Distance;
            hit.ModelHit = this;
            Vector3 normal = (hit.HitPoint - Position) / Scale;
            hit.SetNormal(ref ray, ref normal);
            return true;
        }

        public override Mesh GetMesh()
        {
            return Mesh;
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
                    positions.Add(x);
                    positions.Add(y);
                    positions.Add(z);
                    texCoords.Add(1 - s * S);
                    texCoords.Add(r * R);
                }
            }

            return (positions, texCoords);
        }

        private List<int> GetIndices(short rings, short sectors)
        {
            short r, s;

            List<int> indices = new List<int>(rings * sectors * 6);

            for (r = 0; r < rings - 1; r++)
            {
                for (s = 0; s < sectors - 1; s++)
                {
                    indices.Add((r * sectors + s));
                    indices.Add((r * sectors + (s + 1)));
                    indices.Add(((r + 1) * sectors + (s + 1)));
                    indices.Add(((r + 1) * sectors + (s + 1)));
                    indices.Add((r * sectors + s));
                    indices.Add(((r + 1) * sectors + s));
                }
            }

            return indices;
        }
    }
}