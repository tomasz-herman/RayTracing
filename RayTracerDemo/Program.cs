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
            Camera camera = new LensCamera(new Vector3(0, 0, 8), 0.1f, 8f);
            var scene = new Scene {AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.LightSkyBlue)}};
            scene.AddModel(new Sphere {Position = new Vector3(0, 0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.Orange))});
            scene.AddModel(new Sphere {Position = new Vector3(-2.5f, 0.5f, 1), Scale = 1, Material = new Reflective(Color.FromColor4(Color4.Azure), 0.1f)});
            scene.AddModel(new Sphere {Position = new Vector3(2.5f, 0.5f, 1), Scale = 1, Material = new Reflective(Color.FromColor4(Color4.Aqua), 0.75f)});
            scene.AddModel(new Plane {Position = new Vector3(0, -0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.ForestGreen))});
            var rayTracer = new FileRayTracer("RenderedScene.png", 10, 64, Vec2Sampling.Jittered, 1280);
            rayTracer.Render(scene, camera);
            Console.WriteLine("done");
        }
    }
}