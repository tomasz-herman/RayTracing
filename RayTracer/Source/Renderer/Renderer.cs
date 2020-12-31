using OpenTK.Graphics.OpenGL4;
using RayTracing.Cameras;
using RayTracing.Shaders;
using RayTracing.World;

namespace RayTracing
{
    public class Renderer : IRenderer
    {
        private readonly Shader _shader = new Shader("shader.vert", "shader.frag");

        public void Render(Scene scene, Camera camera)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            var ambient = scene.AmbientLight.Color;
            GL.ClearColor(ambient.R, ambient.G, ambient.B, 1.0f);

            _shader.Use();
            _shader.SetVector3("ambientLight", ambient.ToVector3());

            foreach (var model in scene.Models)
            {
                if (!model.Loaded) continue;
                // _shader.SetMatrix4("model", model.GetModelMatrix());
                _shader.SetMatrix4("mvp", model.GetModelMatrix()*camera.GetViewMatrix()*camera.GetProjectionMatrix());
                model.Material.Use(_shader);
                model.GetMesh().Render();
            }
        }
    }
}