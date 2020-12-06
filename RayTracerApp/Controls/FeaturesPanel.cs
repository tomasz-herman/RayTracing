using RayTracing.Models;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class FeaturesPanel : UserControl, IPanel
    {
        public FeaturesPanel()
        {
            InitializeComponent();
        }

        private IController controller;

        public void SetController(IController newObjectController)
        {
            controller = newObjectController;
        }

        public void UpdateForModel()
        {
            var model = controller.GetModel();
            HideFeaturesControls();
        }

        private void HideFeaturesControls()
        {
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