﻿using RayTracing.Models;
using System.Windows.Forms;

namespace RayTracerApp.Controls.Features
{
    public partial class CubeFeaturesControl : UserControl
    {
        public CubeFeaturesControl()
        {
            InitializeComponent();
        }

        private IController controller;

        public void SetController(IController newObjectController)
        {
            controller = newObjectController;
        }

        private void edgeUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            ((Cube)controller.GetModel()).Edge = (float)nud.Value;
        }
    }
}