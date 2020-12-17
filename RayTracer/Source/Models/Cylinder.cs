using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Cylinder : Model
    {
        private Vector3 _rotation;
        private Vector3 _position;
        private Vector3 _bottom;
        private Vector3 _top;

        private float _height;
        private float _scale = 1.0f;
        private float _aspect;

        
        // Radius = Scale
        // Height = Scale * Aspect
        public Cylinder(float aspect = 1.0f)
        {
            Aspect = aspect;
        }
        
        public override Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                CalculateBottomAndTop();
            }
        }
        
        public override float Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                CalculateBottomAndTop();
            }
        }

        public override Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                CalculateBottomAndTop();
            }
        }

        public float Aspect
        {
            get => _aspect;
            set
            {
                _aspect = value;
                _height = _aspect * _scale;
                CalculateBottomAndTop();
            }
        }

        private void CalculateBottomAndTop()
        {
            Matrix3 rotation = Matrix3.CreateRotationZ(_rotation.Z) * 
                               Matrix3.CreateRotationY(_rotation.Y) * 
                               Matrix3.CreateRotationX(_rotation.X);
            _bottom = -_height * 0.5f * Vector3.UnitY * rotation + Position;
            _top = _height * 0.5f * Vector3.UnitY * rotation + Position;
        }
        
        private protected override void LoadInternal()
        {
            throw new NotImplementedException();
        }

        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            Vector3 dp = ray.Origin - _bottom;
            Vector3 dir = ray.Direction;
            Vector3 vDir = (_top - _bottom) / _height;

            float vDirDotDir = Vector3.Dot(dir, vDir);
            float dpDotVDir = Vector3.Dot(dp, vDir);
            
            Vector3 aVec = dir - vDirDotDir * vDir;
            Vector3 bVec = dp - dpDotVDir * vDir;
            
            float a = Vector3.Dot(aVec, aVec);
            float b = Vector3.Dot(aVec, bVec);
            float c = Vector3.Dot(bVec, bVec) - Scale * Scale;
            
            float delta = b*b - a*c;
            
            if (delta < 0)
                return false;
            
            float deltaSq = (float) Math.Sqrt(delta);

            float root = (-b - deltaSq) / a;
            if (root < from || to < root)
            {
                root = (-b + deltaSq) / a;
                if (root < from || to < root)
                    return false;
            }

            hit.Distance = root;
            hit.ModelHit = this;
            hit.HitPoint = ray.Origin + ray.Direction * hit.Distance;

            Vector3 normal = Vector3.Normalize(_bottom - hit.HitPoint);
            normal = Vector3.Normalize(Vector3.Cross(normal, vDir));
            normal = Vector3.Cross(normal, vDir);
            hit.SetNormal(ref ray, ref normal);

            return true;
        }

        public override Mesh GetMesh()
        {
            throw new NotImplementedException();
        }
    }
}