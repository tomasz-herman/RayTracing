using RayTracerApp.SceneController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Panels
{
    public partial class PositionPanel : UserControl, IPanelBase
    {
        public PositionPanel()
        {
            InitializeComponent();
        }

        public IObjectController Controller { get; set; }

        public void UpdateForModel()
        {
        }

        public void UpdateFromModel()
        {
            var model = Controller.GetModel();
            scaleUpDown.Value = (decimal)model.Scale;

            rollUpDown.Value = (decimal)model.Rotation.Z;
            yawUpDown.Value = (decimal)model.Rotation.Y;
            pitchUpDown.Value = (decimal)model.Rotation.X;

            xUpDown.Value = (decimal)model.Position.X;
            yUpDown.Value = (decimal)model.Position.Y;
            zUpDown.Value = (decimal)model.Position.Z;
        }

        private void zUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var pos = Controller.GetModel().Position;
            pos.Z = (float)nud.Value;
            Controller.GetModel().Position = pos;
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var pos = Controller.GetModel().Position;
            pos.Y = (float)nud.Value;
            Controller.GetModel().Position = pos;
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var pos = Controller.GetModel().Position;
            pos.X = (float)nud.Value;
            Controller.GetModel().Position = pos;
        }

        private void pitchUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = Controller.GetModel().Rotation;
            rotation.X = (float)nud.Value;
            Controller.GetModel().Rotation = rotation;
        }

        private void yawUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = Controller.GetModel().Rotation;
            rotation.Y = (float)nud.Value;
            Controller.GetModel().Rotation = rotation;
        }

        private void rollUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = Controller.GetModel().Rotation;
            rotation.Z = (float)nud.Value;
            Controller.GetModel().Rotation = rotation;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            Controller.GetModel().Scale = (float)nud.Value;
        }
    }
}
