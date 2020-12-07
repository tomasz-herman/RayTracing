using System;
using System.Collections.Generic;
using System.Text;
using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls
{
    interface IPanel
    { 
        void UpdateForModel();
        void SetController(IController controller);

        void ShowPanel();
        void HidePanel();
    }
}
