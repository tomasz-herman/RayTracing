using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls
{
    internal interface IPanel
    {
        void UpdateForModel();
        void SetController(IController controller);
        void ShowPanel();
        void HidePanel();
    }
}