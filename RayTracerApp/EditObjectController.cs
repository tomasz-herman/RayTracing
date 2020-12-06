using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp
{
    class EditObjectController
    {
        private Model model;

        public void SetModel(Model model)
        {
            this.model = model;
        }

        public Model GetModel()
        {
            return model;
        }
    }
}
