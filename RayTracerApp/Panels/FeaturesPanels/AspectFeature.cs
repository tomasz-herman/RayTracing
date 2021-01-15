using RayTracerApp.SceneController;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rectangle = RayTracing.Models.Rectangle;

namespace RayTracerApp.Panels.FeaturesPanels
{
    public partial class AspectFeature : UserControl, IPanelBase
    {
        public AspectFeature()
        {
            InitializeComponent();
        }

        public IObjectController Controller { get; set; }

        public void UpdateForModel()
        {
            var model = Controller.GetModel();
            switch (model)
            {
                case Rectangle rectangle:
                    rectangle.AspectRatio = (float)aspectRatioUpDown.Value;
                    break;
                case Cylinder cylinder:
                    cylinder.Aspect = (float)aspectRatioUpDown.Value;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }

        public void UpdateFromModel()
        {
            var model = Controller.GetModel();
            switch (model)
            {
                case Rectangle rectangle:
                    aspectRatioUpDown.Value = (decimal)rectangle.AspectRatio;
                    break;
                case Cylinder cylinder:
                    aspectRatioUpDown.Value = (decimal)cylinder.Aspect;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }

        private void aspectRatioUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var model = Controller.GetModel();
            switch (model)
            {
                case Rectangle rectangle:
                    rectangle.AspectRatio = val;
                    break;
                case Cylinder cylinder:
                    cylinder.Aspect = val;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }
    }
}
