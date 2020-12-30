using System;
using System.Collections.Generic;
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
            var scene = new Scene {AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.Black)}};
            scene.AddModel(new Cylinder(5) {Position = new Vector3(-5f, 0.5f, -1), Scale = 1, Rotation = new Vector3(1.15f, 0, 3.14f / 2), Material = new Diffuse(Color.FromColor4(Color4.Firebrick))});
            Camera camera = new LensCamera(new Vector3(0, 0, 8), 0.1f, 8f);
            scene.AddModel(new Cylinder(2) {Position = new Vector3(5f, 0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.Chocolate))});
            scene.AddModel(new Sphere {Position = new Vector3(-1, 0.5f, -0.5f), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.Orange))});
            scene.AddModel(new Sphere {Position = new Vector3(0, 5.5f, 0), Scale = 1, Material = new Emissive(Color.FromColor4(Color4.White)*10)});
            scene.AddModel(new Sphere {Position = new Vector3(-2.5f, 0.5f, 1), Scale = 1, Material = new Reflective(Color.FromColor4(Color4.Azure), 0.1f)});
            var matte = new Diffuse(Color.FromColor4(Color4.White));
            var glass = new Refractive(Color.FromColor4(Color4.White), 1.5f);
            var matteGlass = new MasterMaterial {Diffuse = matte, Refractive = glass, DiffusePart = 20, RefractivePart = 80};
            scene.AddModel(new Sphere {Position = new Vector3(2.5f, 0.5f, 1), Scale = 1, Material = matteGlass});
            scene.AddModel(new Plane {Position = new Vector3(0, -0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.ForestGreen))});
            scene.AddModel(new Sphere {Position = new Vector3(5f, 0.5f, 1.5f), Scale = 1, Material = new Diffuse(new Texture("earthmap.jpg", false))});
            scene.AddModel(new Triangle(
                new Vector3(-4f, 0f, -1f),
                new Vector3(-5f, 2f, 2.5f),
                new Vector3(-5f, -0.5f, 2f)
            ) {Material = new Reflective(Color.FromColor4(Color4.AliceBlue), 0.05f)});
            scene.AddModel(new Cube {Position = new Vector3(1.0f, 0.5f, -1.5f), Rotation = new Vector3(-0, 2f, 0), Material = new Diffuse(Color.FromColor4(Color4.Crimson))});
            scene.AddModel(new Sphere {Position = new Vector3(0f, 0.0f, 3.5f), Scale = 0.5f, Material = new Refractive(Color.FromColor4(Color4.White), 1.333f)});
            var rayTracer = new FileRayTracer("RenderedScene.png", 10, 64, Vec2Sampling.Jittered, 1280);
            rayTracer.Render(scene, camera);
            Console.WriteLine("done");
        }
    }
}