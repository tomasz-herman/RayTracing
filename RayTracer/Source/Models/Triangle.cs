using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Triangle : Model
    {
        public override Vector3 Rotation { get; set; }

        private List<Vector3> _vertices;
        private List<float> _vertexBuffer;
        private List<float> _normalBuffer;
        private List<float> _texBuffer;

        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            _vertices = new List<Vector3> {v1, v2, v3};
            LoadBuffers();
        }


        private void LoadBuffers()
        {
            _vertexBuffer = new List<float>();
            foreach (var vertex in _vertices)
            {
                _vertexBuffer.Add(vertex.X);
                _vertexBuffer.Add(vertex.Y);
                _vertexBuffer.Add(vertex.Z);
            }

            _normalBuffer = new List<float>();
            var a = _vertices[1] - _vertices[0];
            var b = _vertices[2] - _vertices[0];
            var normal = Vector3.Cross(a, b);
            _normalBuffer.Add(normal.X);
            _normalBuffer.Add(normal.Y);
            _normalBuffer.Add(normal.Z);

            _texBuffer = new List<float> {0f, 0f, 1f, 1f, 0f, 1f};
        }

        private protected override void LoadInternal()
        {
            Mesh = new Mesh(_vertexBuffer, _normalBuffer, _texBuffer, new List<int> {0, 1, 2});
            Mesh.Load();
        }

        public override bool HitTest(Ray ray, ref HitInfo hit, float @from, float to)
        {
            ray.Direction = ray.Direction.Normalized();
            float u, v, t;
            var v0v1 = _vertices[1] - _vertices[0];
            var v0v2 = _vertices[2] - _vertices[0];
            var pvec = Vector3.Cross(ray.Direction, v0v2);
            var det = Vector3.Dot(v0v1, pvec);

            var kEpsilon = 1e-5f;
            if (Math.Abs(det) < kEpsilon) return false;
            var invDet = 1 / det;

            var tvec = ray.Origin - _vertices[0];
            u = Vector3.Dot(tvec, pvec) * invDet;
            if (u < 0 || u > 1) return false;

            var qvec = Vector3.Cross(tvec, v0v1);
            v = Vector3.Dot(ray.Direction, qvec) * invDet;
            if (v < 0 || u + v > 1) return false;

            t = Vector3.Dot(v0v2, qvec) * invDet;

            if (t > to || t < from) return false;

            hit.ModelHit = this;
            hit.TexCoord = new Vector2(u, v);
            hit.Distance = t;
            hit.HitPoint = ray.Origin + ray.Direction * t;
            var normal = Vector3.Cross(v0v1, v0v2).Normalized();
            if (Vector3.Dot(ray.Direction, normal) <= 0)
            {
                normal *= -1;
            }

            hit.SetNormal(ref ray, ref normal);

            return true;
        }

        public override Mesh GetMesh()
        {
            return Mesh;
        }
    }
}