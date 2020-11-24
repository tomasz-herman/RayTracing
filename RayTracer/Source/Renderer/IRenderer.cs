using RayTracer.Models;
using RayTracer.Utils;

namespace RayTracer
{
    public interface IRenderer
    {
        void Render(Shader shader, Model model);
    }
}