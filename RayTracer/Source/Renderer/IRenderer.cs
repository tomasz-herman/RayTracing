using RayTracer.Models;
using RayTracer.Utils;

namespace RayTracer
{
    public interface IRenderer
    {
        public void Render(Shader shader, Model model);
    }
}