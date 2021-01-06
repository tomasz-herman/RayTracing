using RayTracing.Materials;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp.SceneController
{
    public interface IObjectController
    {
        public MasterMaterial Material
        {
            get;
            set;
        }
        void DeleteModel();
        void SetModel(Model model);
        Model GetModel();
    }
}
