using OpenTK.Graphics.OpenGL4;
using RayTracing.Cameras;
using RayTracing.Shaders;
using RayTracing.World;

namespace RayTracing
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
                _shader.SetMatrix4("model", model.GetModelMatrix());
                model.GetMesh().Render();
            }
        }
    }
}