using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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