using RayTracing.Models;
using RayTracing.World;
using System;

namespace RayTracerApp
{
    public class NewObjectController : IController
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
            _model.Load();
            _scene.AddModel(_model);
        }

        public Model GetModel()
        {
            return _model;
        }

        public void DeleteModel()
        {
            if (_model != null)
            {
                _scene.Models.Remove(_model);
                _model = null;
            }
        }

        public void Dispose()
        {
            _scene = null;
            _model = null;
        }
    }
}