using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Triangle : Model
    {
        private List<Vector3> _vertices;
        private List<Vector2> _texCoords;
        private Vector3 _normal;

        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3, Vector2 tc1 = new Vector2(), Vector2 tc2 = new Vector2(),
            Vector2 tc3 = new Vector2())
        {
            _vertices = new List<Vector3> {v1, v2, v3};
            var a = _vertices[1] - _vertices[0];
            var b = _vertices[2] - _vertices[0];
            _normal = Vector3.Cross(a, b);
            _normal.Normalize();
            _texCoords = new List<Vector2> {tc1, tc2, tc3};
        }

        private protected override void LoadInternal()
        {
            throw new Exception("Triangle is used only in ray tracing");
        }

        public override AABB BoundingBox()
        {
            var outputBox = new AABB(
                Vector3.ComponentMin(Vector3.ComponentMin(_vertices[0], _vertices[1]), _vertices[2]),
                Vector3.ComponentMax(Vector3.ComponentMax(_vertices[0], _vertices[1]), _vertices[2])
            );
            const float thickness = (float) 1e-5;
            const float threshold = (float) 1e-7;
            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(outputBox.Max[i] - outputBox.Min[i]) < threshold)
                {
                    var vec = outputBox.Min;
                    vec[i] -= thickness;
                    outputBox.Min = vec;

                    vec = outputBox.Max;
                    vec[i] += thickness;
                    outputBox.Max = vec;
                }
            }

            return outputBox;
        }

        //source: https://www.scratchapixel.com/code.php?id=9&origin=/lessons/3d-basic-rendering/ray-tracing-rendering-a-triangle
        public override bool HitTest(Ray ray, ref HitInfo hit, float @from, float to)
        {
            ray.Direction = ray.Direction.Normalized();
            float u, v, t;
            var v0v1 = _vertices[1] - _vertices[0];
            var v0v2 = _vertices[2] - _vertices[0];
            var pvec = Vector3.Cross(ray.Direction, v0v2);
            var det = Vector3.Dot(v0v1, pvec);

            if (Math.Abs(det) < Ray.Epsilon) return false;
            var invDet = 1 / det;

            var tvec = ray.Origin - _vertices[0];
            u = Vector3.Dot(tvec, pvec) * invDet;
            if (u < 0 || u > 1) return false;

            var qvec = Vector3.Cross(tvec, v0v1);
            v = Vector3.Dot(ray.Direction, qvec) * invDet;
            if (v < 0 || u + v > 1) return false;

            t = Vector3.Dot(v0v2, qvec) * invDet;

            if (t > to || t < from) return false;

            var uv = _texCoords[0] + u * (_texCoords[1] - _texCoords[0]) + v * (_texCoords[2] - _texCoords[0]);

            hit.ModelHit = this;
            hit.TexCoord = uv;
            hit.Distance = t;
            hit.HitPoint = ray.Origin + ray.Direction * t;
            hit.SetNormal(ref ray, ref _normal);

            return true;
        }

        public override Mesh GetMesh()
        {
            throw new Exception("Triangle is used only in ray tracing");
        }
    }
}