using System;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class PositionPanel : UserControl
    {
        private NewObjectController controller;

        public void SetController(NewObjectController newObjectController)
        {
            controller = newObjectController;
        }

        public PositionPanel()
        {
            InitializeComponent();
        }

        private void zUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Position.Z = (float) nud.Value;
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Position.Y = (float) nud.Value;
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Position.X = (float) nud.Value;
        }

        private void pitchUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Rotation.X = (float) nud.Value;
        }

        private void yawUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Rotation.Y = (float) nud.Value;
        }

        private void rollUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Rotation.Z = (float) nud.Value;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Scale = (float) nud.Value;
        }
    }
}