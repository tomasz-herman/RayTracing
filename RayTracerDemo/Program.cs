using System;
using OpenTK;
using OpenTK.Graphics;
using RayTracing;
using RayTracing.Cameras;
using RayTracing.Lights;
using RayTracing.Materials;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.Sampling;
using RayTracing.World;

namespace RayTracerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new PerspectiveCamera(new Vector3(0, 0, -5)) {AspectRatio = 16f / 9};
            var scene = new Scene();
            scene.AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.LightSkyBlue)};
            scene.AddModel(new Sphere {Position = new Vector3(0, 0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.Orange))});
            scene.AddModel(new Sphere {Position = new Vector3(0, -100.5f, 0), Scale = 100, Material = new Diffuse(Color.FromColor4(Color4.LawnGreen))});
            var rayTracer = new RayTracer(1, 4, new CenterSampler(), 1280){MaxDepth = 10};
            rayTracer.Render(scene, camera);
            Console.WriteLine("done");
        }
    }
}