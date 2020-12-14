﻿using OpenTK;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class CustomModel : Model
    {
        public CustomModel()
        {
        }

        public void SetMesh(Mesh mesh)
        {
            _mesh = mesh;
            _loaded = false;
        }

        public CustomModel(Mesh mesh)
        {
            _mesh = mesh;
        }

        public override Vector3 Rotation { get; set; }

        private protected override void LoadInternal()
        {
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