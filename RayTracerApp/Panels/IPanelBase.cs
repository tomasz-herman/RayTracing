using RayTracerApp.SceneController;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Panels
{
    interface IPanelBase
    {
        IObjectController Controller { get; set; }
        void UpdateForModel();
        void UpdateFromModel();
        void ShowPanel()
        {
            (this as Control).Visible = true;
        }
        void HidePanel()
        {
            (this as Control).Visible = false;
        }
    }
}
