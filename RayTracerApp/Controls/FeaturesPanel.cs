using RayTracing.Models;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class FeaturesPanel : UserControl
    {
        public FeaturesPanel()
        {
            InitializeComponent();
        }

        private NewObjectController controller;

        public void SetController(NewObjectController newObjectController)
        {
            controller = newObjectController;
            sphereFeaturesControl.SetController(controller);
            cubeFeaturesControl.SetController(controller);
        }

        public void UpdateFeatures()
        {
            var model = controller.GetModel();
            HideFeaturesControls();
            switch (model)
            {
                case Sphere sphere:
                    sphereFeaturesControl.Visible = true;
                    break;
                case Cube cube:
                    cubeFeaturesControl.Visible = true;
                    break;
            }
        }

        private void HideFeaturesControls()
        {
            sphereFeaturesControl.Visible = false;
            cubeFeaturesControl.Visible = false;
        }
    }
}