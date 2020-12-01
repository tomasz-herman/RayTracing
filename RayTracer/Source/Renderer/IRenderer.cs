using RayTracer.Cameras;
using RayTracer.World;

namespace RayTracer
{
    public interface IRenderer
    {
        void Render(Scene scene, Camera camera);
    }
}