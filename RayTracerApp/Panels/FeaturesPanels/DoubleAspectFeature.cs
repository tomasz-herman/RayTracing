using RayTracerApp.SceneController;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Panels.FeaturesPanels
{
    public partial class DoubleAspectFeature : UserControl, IPanelBase
    {
        public DoubleAspectFeature()
        {
            InitializeComponent();
        }

        public IObjectController Controller { get; set; }

        public void UpdateForModel()
        {
            var model = Controller.GetModel();
            switch (model)
            {
                case Cuboid cuboid:
                    cuboid.AspectRatio1 = (float)aspect1UpDown.Value;
                    cuboid.AspectRatio2 = (float)aspect2UpDown.Value;
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
                case Cuboid cuboid:
                    aspect1UpDown.Value = (decimal)cuboid.AspectRatio1;
                    aspect2UpDown.Value = (decimal)cuboid.AspectRatio2;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }

        private void aspect1UpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var model = Controller.GetModel();
            switch (model)
            {
                case Cuboid cuboid:
                    cuboid.AspectRatio1 = val;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }

        private void aspect2UpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var model = Controller.GetModel();
            switch (model)
            {
                case Cuboid cuboid:
                    cuboid.AspectRatio2 = val;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }
    }
}
