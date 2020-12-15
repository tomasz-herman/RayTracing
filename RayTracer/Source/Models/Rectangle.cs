using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Rectangle : Model
    {
        public override Vector3 Rotation { get; set; }
        private float _width;
        private float _height;
        private int _xCount;
        private int _yCount;

        public Rectangle(float width, float height, int xCount, int yCount)
        {
            _width = width;
            _height = height;
            _xCount = xCount;
            _yCount = yCount;
        }

        private protected override void LoadInternal()
        {
            var buffers = GetBuffers();
            mesh = new Mesh(buffers.vertexBuffer, buffers.normalBuffer, buffers.texBuffer, buffers.indicesBuffer);
            mesh.Load();
        }

        private Vector3[] GetVertices()
        {
            var vertices = new Vector3[(_xCount + 1) * (_yCount + 1)];
            var halfWidth = _width / 2;
            var halfHeight = _height / 2;
            for (int i = 0, y = 0; y <= _yCount; y++)
            {
                for (int x = 0; x <= _xCount; x++, i++)
                {
                    vertices[i] = new Vector3(_width * x / _xCount-halfWidth, 0, _height * y / _yCount-halfHeight);
                }
            }

            return vertices;
        }

        private int[] GetIndices()
        {
            var indices = new int[_xCount * _yCount * 6];
            for (int ti = 0, vi = 0, y = 0; y < _yCount; y++, vi++)
            {
                for (int x = 0; x < _xCount; x++, ti += 6, vi++)
                {
                    indices[ti] = vi;
                    indices[ti + 3] = indices[ti + 2] = vi + 1;
                    indices[ti + 4] = indices[ti + 1] = vi + _xCount + 1;
                    indices[ti + 5] = vi + _xCount + 2;
                }
            }

            return indices;
        }

        private Vector2[] GetTexCoords()
        {
            return new []
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1)
            };
        }
        
        private int[] GetTexInds()
        {
            return new []
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

        public override bool HitTest(Ray ray, ref HitInfo hit, float @from, float to)
        {
            throw new System.NotImplementedException();
        }

        public override Mesh GetMesh()
        {
            return mesh;
        }
    }
}