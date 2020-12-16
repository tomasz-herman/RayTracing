using System.Windows.Forms;
using RayTracerApp.SceneControllers;
using RayTracing.Models;

namespace RayTracerApp.Controls
{
    public partial class FeaturesPanel : UserControl, IPanel
    {
        private IController _controller;

        public FeaturesPanel()
        {
            InitializeComponent();
        }

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        public void UpdateForModel()
        {
            var model = _controller.GetModel();
            HideFeaturesControls();
            ShowProperControl(model);
        }

        public void ShowPanel()
        {
            Visible = true;
        }

        public void HidePanel()
        {
            Visible = false;
        }

        private void HideFeaturesControls()
        {
            customModelFeatureControl.Visible = false;
        }

        private void ShowProperControl(Model model)
        {
            switch (model)
            {
                case CustomModel customModel:
                    customModelFeatureControl.Visible = true;
                    customModelFeatureControl.SetController(_controller);
                    break;
            }
        }
    }
}