using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp
{
    public class EditObjectController : IController
    {
        private Model model;

        public EditObjectController(Model model)
        {
            this.model = model;
        }

        public void DeleteModel()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.model = null;
        }

        public Model GetModel()
        {
            return model;
        }

        public void SetModel(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
