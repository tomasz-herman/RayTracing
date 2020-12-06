using System;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class PositionPanel : UserControl, IPanel
    {
        private IController controller;

        public void SetController(IController newObjectController)
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
            var rotation = controller.GetModel().Rotation;
            rotation.X = (float) nud.Value;
            controller.GetModel().Rotation = rotation;
        }

        private void yawUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            var rotation = controller.GetModel().Rotation;
            rotation.Y = (float) nud.Value;
            controller.GetModel().Rotation = rotation;
        }

        private void rollUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            var rotation = controller.GetModel().Rotation;
            rotation.Z = (float) nud.Value;
            controller.GetModel().Rotation = rotation;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            controller.GetModel().Scale = (float) nud.Value;
        }

        public void UpdateForModel()
        {
            var model = controller.GetModel();
            this.scaleUpDown.Value = (decimal)model.Scale;

            this.rollUpDown.Value = (decimal)model.Rotation.Z;
            this.yawUpDown.Value = (decimal)model.Rotation.Y;
            this.pitchUpDown.Value = (decimal)model.Rotation.X;

            this.xUpDown.Value = (decimal)model.Position.X;
            this.yUpDown.Value = (decimal)model.Position.Y;
            this.zUpDown.Value = (decimal)model.Position.Z;
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