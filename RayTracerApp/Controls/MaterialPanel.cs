using System.Windows.Forms;
using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls
{
    public partial class MaterialPanel : UserControl, IPanel
    {
        private IController controller;

        public MaterialPanel()
        {
            InitializeComponent();
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        public void UpdateForModel()
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