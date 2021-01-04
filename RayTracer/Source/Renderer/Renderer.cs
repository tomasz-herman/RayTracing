using System;
using OpenTK.Graphics.OpenGL4;
using RayTracing.Cameras;
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
            var lightsCount = Math.Min(MAX_LIGHTS, scene.Lights.Count);
            _shader.SetInt("lightsCount", lightsCount);
            for (int i = 0; i < lightsCount; i++)
            {
                var light = scene.Lights[i];
                _shader.SetVector3($"light[{i}].position", light.Position);
                var color = light.Material.AverageColor;
                _shader.SetVector3($"light[{i}].diffuse", color.ToVector3());
            }

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
    }
}