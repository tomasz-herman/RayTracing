using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Cube : Model
    {
        private Mesh _mesh;

        private List<Vector3> GetVertices()
        {
            return new List<Vector3>
            {
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(1, 1, -1),
                new Vector3(-1, 1, -1),
                new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1),
                new Vector3(1, 1, 1),
                new Vector3(-1, 1, 1)
            };
        }

        private List<int> GetIndices()
        {
            return new List<int>
            {
                0, 1, 3, 3, 1, 2,
                1, 5, 2, 2, 5, 6,
                5, 4, 6, 6, 4, 7,
                4, 0, 7, 7, 0, 3,
                3, 2, 7, 7, 2, 6,
                4, 5, 0, 0, 5, 1
            };
        }

        private List<Vector3> GetNormals()
        {
            return new List<Vector3>
            {
                new Vector3(0, 0, 1),
                new Vector3(1, 0, 0),
                new Vector3(0, 0, -1),
                new Vector3(-1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, -1, 0)
            };
        }

        private List<Vector2> GetTexCoords()
        {
            return new List<Vector2>
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1)
            };
        }

        private List<int> GetTexInds()
        {
            return new List<int>
            {
                0, 1, 3, 3, 1, 2
            };
        }

        private (List<int> indicesBuffer, List<float> vertexBuffer, List<float> texBuffer, List<float> normalBuffer)
            GetBuffers()
        {
            var vertices = GetVertices();
            var indices = GetIndices();
            var normals = GetNormals();
            var texCoords = GetTexCoords();
            var texInds = GetTexInds();

            var vertexBuffer = new List<float>();
            var textureBuffer = new List<float>();
            var normalBuffer = new List<float>();
            var indicesBuffer = new List<int>();

            for (int i = 0; i < indices.Count; i++)
            {
                vertexBuffer.Add(vertices[indices[i]].X); // x
                vertexBuffer.Add(vertices[indices[i]].Y); // y
                vertexBuffer.Add(vertices[indices[i]].Z); // z

                textureBuffer.Add(texCoords[texInds[i % 6]].X); // x
                textureBuffer.Add(texCoords[texInds[i % 6]].Y); // y

                normalBuffer.Add(normals[indices[i / 6]].X); // x
                normalBuffer.Add(normals[indices[i / 6]].Y); // y
                normalBuffer.Add(normals[indices[i / 6]].Z); // z

                indicesBuffer.Add(i);
            }

            return (indicesBuffer, vertexBuffer, textureBuffer, normalBuffer);
        }

        private protected override void LoadInternal()
        {
            var buffers = GetBuffers();
            _mesh = new Mesh(buffers.vertexBuffer, buffers.normalBuffer, buffers.texBuffer, buffers.indicesBuffer);
            _mesh.Load();
        }

        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            throw new System.NotImplementedException();
        }

        public override Mesh GetMesh()
        {
            return _mesh;
        }
    }
}