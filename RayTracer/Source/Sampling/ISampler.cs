using OpenTK;

namespace RayTracer.Sampling
{
    public interface ISampler
    {
        Vector2 Sample();
        Vector2 Sample(int num);
    }
}