using System;
using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Cylinder : Model
    {
        private Plane _bottomPlane;
        private Plane _topPlane;
        private Vector3 _normal;
        
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
                _height = _aspect * _scale;
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
            _normal = (_top - _bottom) / _height;
        }
        
        private protected override void LoadInternal()
        {
            throw new NotImplementedException();
        }

        // https://mrl.cs.nyu.edu/~dzorin/rendering/lectures/lecture3/lecture3-6pp.pdf
        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            hit.Distance = to;
            Vector3 deltaOrigins = ray.Origin - _bottom;
            Vector3 rayDirection = ray.Direction;

            float vDirDotDir = Vector3.Dot(rayDirection, _normal);
            float dpDotVDir = Vector3.Dot(deltaOrigins, _normal);
            
            Vector3 aVec = rayDirection - vDirDotDir * _normal;
            Vector3 bVec = deltaOrigins - dpDotVDir * _normal;
            
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

            Vector3 hitPoint = ray.Origin + ray.Direction * root;

            if (Vector3.Dot(hitPoint - _top, _normal) < 0 && 
                Vector3.Dot(hitPoint - _bottom, _normal) > 0)
            {
                hit.Distance = root;
                hit.ModelHit = this;
                hit.HitPoint = hitPoint;

                Vector3 normal = Vector3.Normalize(_bottom - hit.HitPoint);
                normal = Vector3.Normalize(Vector3.Cross(normal, _normal));
                normal = Vector3.Cross(normal, _normal);
                hit.SetNormal(ref ray, ref normal);
            }

            CapHitTest(ref ray, ref hit, from, to, ref _bottom);
            CapHitTest(ref ray, ref hit, from, to, ref _top);

            return hit.Distance != to;
        }

        public void CapHitTest(ref Ray ray, ref HitInfo hit, float from, float to, ref Vector3 capCenter)
        {
            float t = Vector3.Dot(capCenter - ray.Origin, _normal) / Vector3.Dot(ray.Direction, _normal);
            if (t > hit.Distance) return;
            Vector3 hitPoint = ray.Origin + ray.Direction * t;
            if (t > from && t < to && (hitPoint - capCenter).LengthSquared < Scale * Scale)
            {
                hit.Distance = t;
                hit.HitPoint = hitPoint;
                hit.ModelHit = this;
                hit.SetNormal(ref ray, ref _normal);
            }
        }

        public override Mesh GetMesh()
        {
            throw new NotImplementedException();
        }
    }
}