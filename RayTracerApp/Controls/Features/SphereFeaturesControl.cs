using System;
using System.Windows.Forms;

namespace RayTracerApp.Controls.Features
{
    public partial class SphereFeaturesControl : UserControl
    {
        public SphereFeaturesControl()
        {
            InitializeComponent();
        }

        private NewObjectController controller;

        public void SetController(NewObjectController newObjectController)
        {
            controller = newObjectController;
        }

        private void radiusUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Scale = (float) nud.Value;
        }
    }
}