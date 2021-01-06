using System.Collections.Generic;
using OpenTK;
using RayTracing.Materials;
using RayTracing.Maths;
using RayTracing.RayTracing;

namespace RayTracing.Models
{
    public class Rectangle : Model
    {
        private float _aspectRatio = 1;
        public float AspectRatio
        {
            get => _aspectRatio;
            set
            {
                _aspectRatio = value;
                LoadInternal();
            }
        }

        public Rectangle(float aspect)
        {
            _aspectRatio = aspect;
            Material = new MasterMaterial();
        }

        private protected override void LoadInternal()
        {
            var buffers = GetBuffers();
            Mesh = new Mesh(buffers.vertexBuffer, buffers.normalBuffer, buffers.texBuffer, buffers.indicesBuffer);
            Mesh.Load();
        }

        private Vector3[] GetVertices()
        {
            return new[]
            {
                new Vector3(-0.5f * _aspectRatio, 0, -0.5f),
                new Vector3(0.5f * _aspectRatio, 0, -0.5f),
                new Vector3(-0.5f * _aspectRatio, 0, 0.5f),
                new Vector3(0.5f * _aspectRatio, 0, 0.5f),
            };
        }

        private int[] GetIndices()
        {
            return new[]
            {
                0, 2, 1, 1, 2, 3
            };
        }

        private Vector2[] GetTexCoords()
        {
            return new[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1)
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

        public override bool HitTest(Ray ray, ref HitInfo hit, float @from, float to)
        {
            throw new System.NotImplementedException();
        }

        public override Mesh GetMesh()
        {
            return Mesh;
        }

        public override List<IHittable> Preprocess()
        {
            return MeshToTriangles();
        }
    }
}