using System;
using OpenTK.Graphics.OpenGL4;
using RayTracing.Cameras;
using RayTracing.Materials;
using RayTracing.Shaders;
using RayTracing.World;

namespace RayTracing
{
    public class Renderer : IRenderer
    {
        private const int MAX_LIGHTS = 5;
        private readonly Shader _shader = new Shader("shader.vert", "shader.frag");

        public void Render(Scene scene, Camera camera)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            var ambient = scene.AmbientLight.Color;
            GL.ClearColor(ambient.R, ambient.G, ambient.B, 1.0f);

            _shader.Use();
            for (int i = 0; i < 3; i++)
            {
                _shader.SetInt($"materials[{i}].texture", i);
            }

            _shader.SetVector3("ambientLight", ambient.ToVector3());
            _shader.SetVector3("cameraPosition", camera.Position);

            AddLights(scene);
            foreach (var model in scene.Models)
            {
                if (!model.Loaded) continue;
                _shader.SetMatrix4("model", model.GetModelMatrix());
                _shader.SetMatrix4("mvp",
                    model.GetModelMatrix() * camera.GetViewMatrix() * camera.GetProjectionMatrix());
                model.Material.Use(_shader);
                model.GetMesh().Render();
            }
        }

        private void AddLights(Scene scene)
        {
            var lightsCount = 0;
            foreach (var model in scene.Models)
            {
                if (model.Material is Emissive || model.Material is MasterMaterial &&
                (model.Material as MasterMaterial).Parts.emissive != 0)
                {
                    if (lightsCount < MAX_LIGHTS)
                    {
                        var light = model;
                        _shader.SetVector3($"light[{lightsCount}].position", light.Position);
                        var color = light.Material.AverageColor;
                        _shader.SetVector3($"light[{lightsCount}].diffuse", color.ToVector3());
                        lightsCount++;
                    }
                }
            }
            _shader.SetInt("lightsCount", lightsCount);
        }
    }
}