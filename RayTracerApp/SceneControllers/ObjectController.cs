using RayTracing.Models;
using RayTracing.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp.SceneControllers
{
    class ObjectController : IController
    {
        protected Scene scene;
        protected Model model;

        public void DeleteModel()
        {
            if (this.model != null)
            {
                this.scene.Models.Remove(this.model);
                this.model = null;
            }
        }

        public void Dispose()
        {
            this.scene = null;
            this.model = null;
        }

        public Model GetModel()
        {
            return this.model;
        }

        public void SetModel(Model model)
        {
            DeleteModel();
            this.model = model;
            if(this.model != null)
            {
                this.scene.AddModel(this.model);
            }
        }
    }
}
