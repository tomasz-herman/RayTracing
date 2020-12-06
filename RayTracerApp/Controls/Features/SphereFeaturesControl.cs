using System;
using System.Windows.Forms;
using RayTracing.Models;

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
            ((Sphere)controller.GetModel()).Radius = (float) nud.Value;
        }
    }
}