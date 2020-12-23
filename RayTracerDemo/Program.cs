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
            Camera camera = new PerspectiveCamera(new Vector3(0, 0, 8));
            var scene = new Scene {AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.LightSkyBlue)}};
            scene.AddModel(new Cylinder(5) {Position = new Vector3(-5f, 0.5f, -1), Scale = 1, Rotation = new Vector3(-0, 1.15f, 3.14f / 2), Material = new Diffuse(Color.FromColor4(Color4.Firebrick))});
            scene.AddModel(new Cylinder(2) {Position = new Vector3(5f, 0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.Chocolate))});
            scene.AddModel(new Sphere {Position = new Vector3(0, 0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.Orange))});
            scene.AddModel(new Sphere {Position = new Vector3(0, 5.5f, 0), Scale = 1, Material = new Emissive(Color.FromColor4(Color4.White)*10)});
            scene.AddModel(new Sphere {Position = new Vector3(-2.5f, 0.5f, 1), Scale = 1, Material = new Reflective(Color.FromColor4(Color4.Azure), 0.1f)});
            scene.AddModel(new Sphere {Position = new Vector3(2.5f, 0.5f, 1), Scale = 1, Material = new Reflective(Color.FromColor4(Color4.Aqua), 0.75f)});
            scene.AddModel(new Plane {Position = new Vector3(0, -0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.ForestGreen))});
            scene.AddModel(new Triangle(
                new Vector3(-4f, 0f, -1f),
                new Vector3(-5f, 2f, 2.5f),
                new Vector3(-5f, -0.5f, 2f)
            ) {Material = new Reflective(Color.FromColor4(Color4.AliceBlue), 0.05f)});
            scene.AddModel(new Sphere {Position = new Vector3(3f, 0.5f, 3.5f), Scale = 0.7f, Material = new Refractive(1.333f)});
            var rayTracer = new FileRayTracer("RenderedScene.png", 10, 64, Vec2Sampling.Jittered, 1280);
            rayTracer.Render(scene, camera);
            Console.WriteLine("done");
        }
    }
}