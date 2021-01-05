using System;
using System.Collections.Generic;
using OpenTK;
using RayTracing.Materials;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class Cylinder : Model
    {
        private Vector3 _normal;
        private Vector3 _bottom;
        private Vector3 _top;

        private float _height;
        private float _aspect;
        private readonly int _sectorCount;

        // Radius = Scale
        // Height = Scale * Aspect
        public Cylinder(float aspect = 1.0f, int sectorCount = 100)
        {
            _sectorCount = sectorCount;
            Aspect = aspect;
            Material = new MasterMaterial();
        }

        public override Vector3 Rotation
        {
            set
            {
                base.Rotation = value;
                Recalculate();
            }
        }

        public override float Scale
        {
            set
            {
                base.Scale = value;
                _height = _aspect * value;
                Recalculate();
            }
        }

        public override Vector3 Position
        {
            set
            {
                base.Position = value;
                Recalculate();
            }
        }

        public float Aspect
        {
            get => _aspect;
            set
            {
                _aspect = value;
                _height = _aspect * Scale;
                Recalculate();
                if (loaded)
                {
                    Unload();
                    Load();
                }
            }
        }

        private void Recalculate()
        {
            _normal = Vector3.UnitY * RotationMatrix;
            _bottom = -_height * 0.5f * _normal + Position;
            _top = _height * 0.5f * _normal + Position;
        }

        private protected override void LoadInternal()
        {
            var buffers = GetBuffers();
            Mesh = new Mesh(buffers.vertexBuffer, buffers.normalBuffer, buffers.texBuffer, buffers.indicesBuffer);
            Mesh.Load();
        }

        // https://mrl.cs.nyu.edu/~dzorin/rendering/lectures/lecture3/lecture3-6pp.pdf
        public override bool HitTest(Ray ray, ref HitInfo hit, float from, float to)
        {
            hit.Distance = to;
            Vector3 deltaOrigins = ray.Origin - _bottom;
            Vector3 rayDirection = ray.Direction;

            Vector3 aVec = rayDirection - Vector3.Dot(rayDirection, _normal) * _normal;
            Vector3 bVec = deltaOrigins - Vector3.Dot(deltaOrigins, _normal) * _normal;

            float a = Vector3.Dot(aVec, aVec);
            float bHalf = Vector3.Dot(aVec, bVec);
            float c = Vector3.Dot(bVec, bVec) - Scale * Scale;

            float delta = bHalf * bHalf - a * c;

            if (delta < 0)
                return false;

            float deltaSq = (float) Math.Sqrt(delta);

            float root = (-bHalf - deltaSq) / a;
            if (root < from || to < root)
            {
                root = (-bHalf + deltaSq) / a;
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
                GetCylinderUV(hitPoint, ref hit.TexCoord);
            }

            CapHitTest(ref ray, ref hit, from, to, ref _bottom);
            CapHitTest(ref ray, ref hit, from, to, ref _top);

            return hit.Distance != to;
        }

        private void CapHitTest(ref Ray ray, ref HitInfo hit, float from, float to, ref Vector3 capCenter)
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
                GetCapUV(hitPoint, ref hit.TexCoord);
            }
        }
        
        // https://www.iquilezles.org/www/articles/diskbbox/diskbbox.htm
        public override AABB BoundingBox()
        {
            var normal = _normal.Normalized();
            float x = (float) Math.Sqrt(1 - normal.X * normal.X);
            float y = (float) Math.Sqrt(1 - normal.Y * normal.Y);
            float z = (float) Math.Sqrt(1 - normal.Z * normal.Z);
            Vector3 e = new Vector3(x, y, z) * Scale;
            return new AABB(
                Vector3.ComponentMin(_top - e, _bottom - e),
                Vector3.ComponentMax(_top + e, _bottom + e));
        }
        
        private void GetCylinderUV(Vector3 hitPoint, ref Vector2 uv)
        {
            var hitVector = RotationMatrix * (hitPoint - Position) / _height;

            var phi = Math.Atan2(hitVector.Z, -hitVector.X) + Math.PI;
            uv.X = (float) (phi / (2 * Math.PI));
            uv.Y = 0.5f - hitVector.Y;
        }
        
        private void GetCapUV(Vector3 hitPoint, ref Vector2 uv)
        {
            var hitVector = RotationMatrix * (hitPoint - Position) / Scale;
            uv.X = 1 - (hitVector.X + 1) * 0.5f;
            uv.Y = 1 - (hitVector.Z + 1) * 0.5f;
        }

        public override Mesh GetMesh()
        {
            return Mesh;
        }

        // http://www.songho.ca/opengl/gl_cylinder.html#cylinder
        private List<float> GetUnitCircleVertices()
        {
            float sectorStep = (float) (2 * Math.PI / _sectorCount);

            var unitCircleVertices = new List<float>();
            for(int i = 0; i <= _sectorCount; ++i)
            {
                var sectorAngle = i * sectorStep;
                unitCircleVertices.Add((float)Math.Cos(sectorAngle));
                unitCircleVertices.Add((float)Math.Sin(sectorAngle));
                unitCircleVertices.Add(0);
            }
            return unitCircleVertices;
        }
        
        // http://www.songho.ca/opengl/gl_cylinder.html#cylinder
        private (List<int> indicesBuffer, List<float> vertexBuffer, List<float> texBuffer, List<float> normalBuffer) GetBuffers()
        {
            var unitVertices = GetUnitCircleVertices();
            var vertices = new List<float>();
            var normals = new List<float>();
            var texCoords = new List<float>();
            
            float height = _aspect;
            float radius = 1f;
            
            for(int i = 0; i < 2; ++i)
            {
                float h = -height / 2.0f + i * height;
                float t = 1.0f - i;

                for(int j = 0, k = 0; j <= _sectorCount; ++j, k += 3)
                {
                    float ux = unitVertices[k];
                    float uy = unitVertices[k+1];
                    float uz = unitVertices[k+2];
                    
                    vertices.Add(ux * radius);
                    vertices.Add(h);
                    vertices.Add(uy * radius);
                    
                    normals.Add(ux);
                    normals.Add(uz);
                    normals.Add(uy);
                    
                    texCoords.Add(1 - (float)j / _sectorCount);
                    texCoords.Add(t);
                }
            }
            
            int baseCenterIndex = vertices.Count / 3;
            int topCenterIndex = baseCenterIndex + _sectorCount + 1;
            
            for(int i = 0; i < 2; ++i)
            {
                float h = -height / 2.0f + i * height;
                float nz = -1 + i * 2;
                
                vertices.Add(0);     vertices.Add(h);     vertices.Add(0);
                normals.Add(0);      normals.Add(nz);      normals.Add(0);
                texCoords.Add(0.5f); texCoords.Add(0.5f);

                for(int j = 0, k = 0; j < _sectorCount; ++j, k += 3)
                {
                    float ux = unitVertices[k];
                    float uy = unitVertices[k+1];
                    
                    vertices.Add(ux * radius);
                    vertices.Add(h);
                    vertices.Add(uy * radius);

                    normals.Add(0);
                    normals.Add(nz);
                    normals.Add(0);

                    texCoords.Add(-ux * 0.5f + 0.5f);
                    texCoords.Add(-uy * 0.5f + 0.5f);
                }
            }

            var indices = GenIndices(topCenterIndex, baseCenterIndex);

            return (indices, vertices, texCoords, normals);
        }

        // http://www.songho.ca/opengl/gl_cylinder.html#cylinder
        private List<int> GenIndices(int topCenterIndex, int baseCenterIndex)
        {
            var indices = new List<int>();
            int k1 = 0;
            int k2 = _sectorCount + 1;
            
            for(int i = 0; i < _sectorCount; ++i, ++k1, ++k2)
            {
                indices.Add(k1);
                indices.Add(k1 + 1);
                indices.Add(k2);

                indices.Add(k2);
                indices.Add(k1 + 1);
                indices.Add(k2 + 1);
            }
            
            for(int i = 0, k = baseCenterIndex + 1; i < _sectorCount; ++i, ++k)
            {
                if(i < _sectorCount - 1)
                {
                    indices.Add(baseCenterIndex);
                    indices.Add(k + 1);
                    indices.Add(k);
                }
                else
                {
                    indices.Add(baseCenterIndex);
                    indices.Add(baseCenterIndex + 1);
                    indices.Add(k);
                }
            }
            
            for(int i = 0, k = topCenterIndex + 1; i < _sectorCount; ++i, ++k)
            {
                if(i < _sectorCount - 1)
                {
                    indices.Add(topCenterIndex);
                    indices.Add(k);
                    indices.Add(k + 1);
                }
                else
                {
                    indices.Add(topCenterIndex);
                    indices.Add(k);
                    indices.Add(topCenterIndex + 1);
                }
            }

            return indices;
        }
    }
}