using RayTracing.Models;
using RayTracing.World;
using System;

namespace RayTracerApp
{
    public class NewObjectController : IDisposable
    {
        private Model _model;
        private Scene _scene;

        public NewObjectController(Scene scene)
        {
            _scene = scene;
        }

        public void SetModel(Model model)
        {
            DeleteModel();
            _model = model;
            _scene.AddModel(_model);
        }

        public Model GetModel()
        {
            return _model;
        }

        private void DeleteModel()
        {
            if (_model != null)
            {
                _scene.Models.Remove(_model);
                _model = null;
            }
        }

        public void Dispose()
        {
            DeleteModel();
            _scene = null;
        }
    }
}