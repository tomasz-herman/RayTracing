using OpenTK.Graphics.OpenGL4;
using RayTracer.Cameras;
using RayTracer.Models;
using RayTracer.Utils;
using RayTracer.World;

namespace RayTracer
{
    public class Renderer : IRenderer
    {
        private Shader _shader = new Shader("shader.vert", "shader.frag");
        
        public void Render(Scene scene, Camera camera)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            var ambient = scene.AmbientLight.Color;
            GL.ClearColor(ambient.R, ambient.G, ambient.B, 1.0f);
            
            _shader.Use();
            _shader.SetMatrix4("view", camera.GetViewMatrix());
            _shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            foreach (var model in scene.Models)
            {
                model.GetMesh().Render();
            }
        }
    }
}