﻿using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Triangle : Model
    {
        public override Vector3 Rotation { get; set; }

        private List<Vector3> _vertices;
        private Vector3 _normal;

        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            _vertices = new List<Vector3> {v1, v2, v3};
            var a = _vertices[1] - _vertices[0];
            var b = _vertices[2] - _vertices[0];
            _normal = Vector3.Cross(a, b);
        }

        private protected override void LoadInternal()
        {
            throw new Exception("Triangle is used only in ray tracing");
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
            var normal = _normal;
            if (Vector3.Dot(ray.Direction, normal) <= 0)
            {
                normal *= -1;
            }

            hit.SetNormal(ref ray, ref normal);

            return true;
        }

        public override Mesh GetMesh()
        {
            throw new Exception("Triangle is used only in ray tracing");
        }
    }
}