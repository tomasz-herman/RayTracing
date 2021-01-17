using OpenTK;
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

        float FromDegreesToRadians(decimal degrees)
        {
            return (float)(degrees / 180) * (float)Math.PI;
        }

        decimal FromRadiansToDegrees(float radians)
        {
            return (decimal)(radians / (float)Math.PI * 180);
        }

        public void UpdateForModel()
        {
            var model = Controller.GetModel();
            model.Scale = (float)scaleUpDown.Value;
            var rotation = new Vector3
            {

                X = FromDegreesToRadians(pitchUpDown.Value),
                Y = FromDegreesToRadians(yawUpDown.Value),
                Z = FromDegreesToRadians(rollUpDown.Value)
        };
            model.Rotation = rotation;

            var position = new Vector3
            {
                X = (float)xUpDown.Value,
                Y = (float)yUpDown.Value,
                Z = (float)zUpDown.Value
            };
            model.Position = position;
        }

        public void UpdateFromModel()
        {
            var model = Controller.GetModel();
            scaleUpDown.Value = (decimal)model.Scale;

            rollUpDown.Value = FromRadiansToDegrees(model.Rotation.Z);
            yawUpDown.Value = FromRadiansToDegrees(model.Rotation.Y);
            pitchUpDown.Value = FromRadiansToDegrees(model.Rotation.X);

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
            rotation.X = FromDegreesToRadians(nud.Value);
            Controller.GetModel().Rotation = rotation;
        }

        private void yawUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = Controller.GetModel().Rotation;
            rotation.Y = FromDegreesToRadians(nud.Value);
            Controller.GetModel().Rotation = rotation;
        }

        private void rollUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            var rotation = Controller.GetModel().Rotation;
            rotation.Z = FromDegreesToRadians(nud.Value);
            Controller.GetModel().Rotation = rotation;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            Controller.GetModel().Scale = (float)nud.Value;
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;

            ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.Bottom);
        }
    }
}
