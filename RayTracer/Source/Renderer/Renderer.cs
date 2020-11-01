using RayTracer.Models;
using RayTracer.Utils;

namespace RayTracer
{
    public class Renderer : IRenderer
    {
        public void Render(Shader shader, Model model)
        {
            shader.Use();
            model.GetMesh().Render();
        }
    }
}