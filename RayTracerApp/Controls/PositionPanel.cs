using System;
using System.Windows.Forms;
using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls
{
    public partial class PositionPanel : UserControl, IPanel
    {
        private IController _controller;

        public PositionPanel()
        {
            InitializeComponent();
        }

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        public void UpdateForModel()
        {
            var model = _controller.GetModel();
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
            var pos = _controller.GetModel().Position;
            pos.Z = (float) nud.Value;
            _controller.GetModel().Position = pos;
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var pos = _controller.GetModel().Position;
            pos.Y = (float) nud.Value;
            _controller.GetModel().Position = pos;
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var pos = _controller.GetModel().Position;
            pos.X = (float) nud.Value;
            _controller.GetModel().Position = pos;
        }

        private void pitchUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = _controller.GetModel().Rotation;
            rotation.X = (float) nud.Value;
            _controller.GetModel().Rotation = rotation;
        }

        private void yawUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = _controller.GetModel().Rotation;
            rotation.Y = (float) nud.Value;
            _controller.GetModel().Rotation = rotation;
        }

        private void rollUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = _controller.GetModel().Rotation;
            rotation.Z = (float) nud.Value;
            _controller.GetModel().Rotation = rotation;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            _controller.GetModel().Scale = (float) nud.Value;
        }
    }
}