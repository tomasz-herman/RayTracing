using RayTracing.Cameras;
using RayTracing.World;

namespace RayTracing
{
    public interface IRenderer
    {
        void Render(Scene scene, Camera camera);
    }
}