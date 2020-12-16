using RayTracing.Models;
using RayTracing.World;

namespace RayTracerApp.SceneControllers
{
    internal class ObjectController : IController
    {
        protected Model model;
        protected Scene scene;

        public void DeleteModel()
        {
            if (model != null)
            {
                scene.Models.Remove(model);
                model = null;
            }
        }

        public void Dispose()
        {
            scene = null;
            model = null;
        }

        public Model GetModel()
        {
            return model;
        }

        public void SetModel(Model model)
        {
            DeleteModel();
            this.model = model;
            if (this.model != null) scene.AddModel(this.model);
        }
    }
}