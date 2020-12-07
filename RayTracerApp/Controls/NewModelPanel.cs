using System;
using System.Windows.Forms;
using RayTracerApp.SceneControllers;
using RayTracing.Models;

namespace RayTracerApp.Controls
{
    public partial class NewModelPanel : UserControl, IPanel
    {
        private IController controller;

        public NewModelPanel()
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
            Visible = true;
        }

        public void HidePanel()
        {
            Visible = false;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            if (rb.Checked)
                switch (rb.Text)
                {
                    case "Sphere":
                        controller.SetModel(new Sphere().Load());
                        break;
                    case "Cube":
                        controller.SetModel(new Cube().Load());
                        break;
                    case "Custom model":
                        controller.SetModel(new CustomModel());
                        break;
                }
        }
    }
}