using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Plane : Model
    {
        private Vector3 _normal = Vector3.UnitY;
        private Vector3 _rotation;

        public override Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                _normal= Vector3.UnitY;
                _normal *= Matrix3.CreateRotationX(_rotation.X);
                _normal *= Matrix3.CreateRotationY(_rotation.Y);
                _normal *= Matrix3.CreateRotationZ(_rotation.Z);
            }
        }

        private protected override void LoadInternal()
        {
            mesh = new Rectangle(1000,1000,100,100).Load().GetMesh();
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
                return true;
            }

            return false;
        }

        public override Mesh GetMesh()
        {
            return mesh;
        }
    }
}