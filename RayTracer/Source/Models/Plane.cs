using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Plane : Model
    {
        private Vector3 _normal = Vector3.UnitY;
        private int _sideCount = 1000;

        public override Vector3 Rotation
        {
            set
            {
                base.Rotation = value;
                _normal = Vector3.UnitY * RotationMatrix;
            }
        }

        private protected override void LoadInternal()
        {
            var buffers = GetBuffers();
            Mesh = new Mesh(buffers.vertexBuffer, buffers.normalBuffer, buffers.texBuffer, buffers.indicesBuffer);
            Mesh.Load();
        }

        private Vector3[] GetVertices()
        {
            var vertices = new Vector3[(_sideCount + 1) * (_sideCount + 1)];
            var halfWidth = _sideCount / 2;
            var halfHeight = _sideCount / 2;
            for (int i = 0, y = 0; y <= _sideCount; y++)
            {
                for (int x = 0; x <= _sideCount; x++, i++)
                {
                    vertices[i] = new Vector3(x - halfWidth, 0, y - halfHeight);
                }
            }

            return vertices;
        }

        private int[] GetIndices()
        {
            var indices = new int[_sideCount * _sideCount * 6];
            for (int ti = 0, vi = 0, y = 0; y < _sideCount; y++, vi++)
            {
                for (int x = 0; x < _sideCount; x++, ti += 6, vi++)
                {
                    indices[ti] = vi;
                    indices[ti + 3] = indices[ti + 2] = vi + 1;
                    indices[ti + 4] = indices[ti + 1] = vi + _sideCount + 1;
                    indices[ti + 5] = vi + _sideCount + 2;
                }
            }

            return indices;
        }

        private Vector2[] GetTexCoords()
        {
            return new[]
            {
                new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(1, 0),
                new Vector2(0, 0)
            };
        }

        private int[] GetTexInds()
        {
            return new[]
            {
                0, 1, 3, 3, 1, 2
            };
        }

        private (List<int> indicesBuffer, List<float> vertexBuffer, List<float> texBuffer, List<float> normalBuffer)
            GetBuffers()
        {
            var vertices = GetVertices();
            var indices = GetIndices();
            var normal = new Vector3(0, 1, 0);
            var texCoords = GetTexCoords();
            var texInds = GetTexInds();

            var vertexBuffer = new List<float>();
            var textureBuffer = new List<float>();
            var normalBuffer = new List<float>();
            var indicesBuffer = new List<int>();

            for (int i = 0; i < indices.Length; i++)
            {
                vertexBuffer.Add(vertices[indices[i]].X);
                vertexBuffer.Add(vertices[indices[i]].Y);
                vertexBuffer.Add(vertices[indices[i]].Z);

                textureBuffer.Add(texCoords[texInds[i % 6]].X);
                textureBuffer.Add(texCoords[texInds[i % 6]].Y);

                normalBuffer.Add(normal.X);
                normalBuffer.Add(normal.Y);
                normalBuffer.Add(normal.Z);

                indicesBuffer.Add(i);
            }

            return (indicesBuffer, vertexBuffer, textureBuffer, normalBuffer);
        }

        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            float t = Vector3.Dot(Position - ray.Origin, _normal) / Vector3.Dot(ray.Direction, _normal);
            if (t > from && t < to)
            {
                hit.Distance = t;
                hit.HitPoint = ray.Origin + ray.Direction * hit.Distance;
                hit.ModelHit = this;
                hit.SetNormal(ref ray, ref _normal);
                var hitVector = RotationMatrix * (hit.HitPoint - Position);
                hit.TexCoord = new Vector2(
                    hitVector.Z / Scale,
                    (Scale - hitVector.X) / Scale);
                return true;
            }

            return false;
        }

        public override Mesh GetMesh()
        {
            return Mesh;
        }
    }
}