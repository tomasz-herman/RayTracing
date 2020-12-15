using System.Windows.Forms;
using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls
{
    public partial class MaterialPanel : UserControl, IPanel
    {
        private IController _controller;

        public MaterialPanel()
        {
            InitializeComponent();
        }

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        public void UpdateForModel()
        {
        }

        public void ShowPanel()
        {
            Visible = true;
        }

        public void HidePanel()
        {
            Visible = false;
        }
    }
}