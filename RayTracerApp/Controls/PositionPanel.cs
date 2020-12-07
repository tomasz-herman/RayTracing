using System;
using System.Windows.Forms;
using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls
{
    public partial class PositionPanel : UserControl, IPanel
    {
        private IController controller;

        public PositionPanel()
        {
            InitializeComponent();
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        public void UpdateForModel()
        {
            var model = controller.GetModel();
            scaleUpDown.Value = (decimal) model.Scale;

            rollUpDown.Value = (decimal) model.Rotation.Z;
            yawUpDown.Value = (decimal) model.Rotation.Y;
            pitchUpDown.Value = (decimal) model.Rotation.X;

            xUpDown.Value = (decimal) model.Position.X;
            yUpDown.Value = (decimal) model.Position.Y;
            zUpDown.Value = (decimal) model.Position.Z;
        }

        public void ShowPanel()
        {
            Visible = true;
        }

        public void HidePanel()
        {
            Visible = false;
        }

        private void zUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            controller.GetModel().Position.Z = (float) nud.Value;
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            controller.GetModel().Position.Y = (float) nud.Value;
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            controller.GetModel().Position.X = (float) nud.Value;
        }

        private void pitchUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = controller.GetModel().Rotation;
            rotation.X = (float) nud.Value;
            controller.GetModel().Rotation = rotation;
        }

        private void yawUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = controller.GetModel().Rotation;
            rotation.Y = (float) nud.Value;
            controller.GetModel().Rotation = rotation;
        }

        private void rollUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = controller.GetModel().Rotation;
            rotation.Z = (float) nud.Value;
            controller.GetModel().Rotation = rotation;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            controller.GetModel().Scale = (float) nud.Value;
        }
    }
}