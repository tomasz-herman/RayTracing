using RayTracer.Models;
using RayTracer.Utils;

namespace RayTracer.Renderer
{
    public interface IRenderer
    {
        public void Render(Shader shader, Model model);
    }
}