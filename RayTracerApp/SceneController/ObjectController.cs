using RayTracing.Materials;
using RayTracing.Models;
using RayTracing.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp.SceneController
{
    public class ObjectController : IObjectController
    {
        protected Model model;
        protected Scene scene;
        protected MasterMaterial _material;
        public MasterMaterial Material
        {
            get => _material;
            set => _material = value;
        }
        public Action UpdateModelFromUI { get; set; }

        public ObjectController(Scene scene)
        {
            this.scene = scene;
        }

        public ObjectController(Scene scene, Model model)
        {
            this.scene = scene;
            this.model = model;
            Material = (MasterMaterial)model.Material;
        }

        public void DeleteModel()
        {
            if (model != null)
            {
                scene.Models.Remove(model);
                model = null;
            }
        }
        public Model GetModel()
        {
            return model;
        }

        public void SetModel(Model model)
        {
            DeleteModel();
            this.model = model;
            if (Material == null)
            {
                Material = (MasterMaterial)model.Material;
            }
            else
            {
                model.Material = Material;
            }

            if (this.model != null) scene.AddModel(this.model);
        }

        public Scene GetScene()
        {
            return scene;
        }
    }
}
