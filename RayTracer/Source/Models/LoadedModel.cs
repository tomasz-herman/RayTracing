﻿using RayTracer.Maths;

namespace RayTracer.Models
{
    public class LoadedModel : Model
    {
        public Mesh mesh;
        public override HitInfo HitTest(Ray ray, HitInfo hitInfo)
        {
            throw new System.NotImplementedException();
        }

        public override Mesh GetMesh()
        {
            return mesh;
        }
        
    }
}