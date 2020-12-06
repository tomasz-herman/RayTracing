using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class MaterialPanel : UserControl
    {
        private NewObjectController controller;

        public MaterialPanel()
        {
            InitializeComponent();
        }

        public void SetController(NewObjectController controller)
        {
            this.controller = controller;
        }
    }
}