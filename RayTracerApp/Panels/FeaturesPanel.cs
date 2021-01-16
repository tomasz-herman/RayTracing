using RayTracerApp.SceneController;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Panels
{
    public partial class FeaturesPanel : UserControl, IPanelBase
    {
        public FeaturesPanel()
        {
            InitializeComponent();
        }

        private IObjectController _controller;
        public IObjectController Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;
                customModelFeature.Controller = _controller;
                aspectFeature.Controller = _controller;
                doubleAspectFeature.Controller = _controller;
            }
        }

        public void UpdateForModel()
        {
            var model = Controller.GetModel();
            switch (model)
            {
                case Rectangle rectangle:
                case Cylinder cylinder:
                    aspectFeature.UpdateForModel();
                    break;
                case Cuboid cuboid:
                    doubleAspectFeature.UpdateForModel();
                    break;
                case CustomModel customModel:
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
                case Cylinder cylinder:
                    aspectFeature.UpdateFromModel();
                    break;
                case Cuboid cuboid:
                    doubleAspectFeature.UpdateFromModel();
                    break;
                case CustomModel customModel:
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }

        private void FeaturesPanel_VisibleChanged(object sender, EventArgs e)
        {
            customModelFeature.Visible = false;
            aspectFeature.Visible = false;
            doubleAspectFeature.Visible = false;

            var model = Controller?.GetModel();
            if (model == null) return;
            switch (model)
            {
                case Rectangle rectangle:
                case Cylinder cylinder:
                    aspectFeature.Visible = true;
                    break;
                case Cuboid cuboid:
                    doubleAspectFeature.Visible = true;
                    break;
                case CustomModel customModel:
                    customModelFeature.Visible = true;
                    break;
                default:
                    throw new Exception("Bad model type");
            }

        }
    }
}
