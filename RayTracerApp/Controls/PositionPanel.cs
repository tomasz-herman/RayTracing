using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class PositionPanel : UserControl
    {
        private NewObjectController _controller;
        public void SetController(NewObjectController newObjectController)
        {
            _controller = newObjectController;
        }
        public PositionPanel()
        {
            InitializeComponent();
        }

        private void zUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            _controller.GetModel().Position.Z = (float)nud.Value;
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            _controller.GetModel().Position.Y = (float)nud.Value;
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            _controller.GetModel().Position.X = (float)nud.Value;
        }
    }
}
