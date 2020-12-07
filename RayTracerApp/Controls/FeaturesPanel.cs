using RayTracing.Models;
using System.Windows.Forms;
using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls
{
    public partial class FeaturesPanel : UserControl, IPanel
    {
        public FeaturesPanel()
        {
            InitializeComponent();
        }

        private IController controller;

        public void SetController(IController controller)
        {
            this.controller = controller;

        }

        public void UpdateForModel()
        {
            var model = controller.GetModel();
            HideFeaturesControls();
            ShowProperControl(model);
        }

        private void HideFeaturesControls()
        {
            customModelFeatureControl.Visible = false;
        }
        private void ShowProperControl(Model model)
        {
            switch(model)
            {
                case CustomModel customModel:
                    customModelFeatureControl.Visible = true;
                    customModelFeatureControl.SetController(this.controller);
                    break;
            }
        }

        public void ShowPanel()
        {
            this.Visible = true;
        }

        public void HidePanel()
        {
            this.Visible = false;
        }
    }
}