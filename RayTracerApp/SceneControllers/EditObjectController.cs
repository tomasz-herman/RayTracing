using RayTracing.Models;
using RayTracing.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp.SceneControllers
{
    class EditObjectController : ObjectController
    {
        public EditObjectController(Scene scene, Model model)
        {
            this.scene = scene;
            this.model = model;
        }
    }
}
