using RayTracer.Models;
using RayTracer.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp
{
    public class NewObjectController
    {
        private Model _model;

        private Scene _scene;
        public NewObjectController(Scene scene)
        {
            _scene = scene;
        }
        public void SetModel(Model model)
        {
            _model = model;
            _scene.AddModel(_model);
        }
        public Model GetModel()
        {
            return _model;
        }
    }
}
