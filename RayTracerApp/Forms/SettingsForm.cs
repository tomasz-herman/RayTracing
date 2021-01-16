using RayTracerApp.SceneController;
using RayTracing;
using RayTracing.Cameras;
using RayTracing.Sampling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Forms
{
    public partial class SettingsForm : Form
    {
        private SettingsController _controller;
        public SettingsForm(SettingsController controller)
        {
            _controller = controller;
            InitializeComponent();
            LoadFromController();
        }

        private void LoadFromController()
        {
            var camera = _controller.Camera;
            var rayTracer = _controller.RayTracer;

            perspectiveCameraRadioButton.Checked = camera is PerspectiveCamera;
            lensCameraRadioButton.Checked = camera is LensCamera;
            ortographicCameraRadioButton.Checked = camera is OrthographicCamera;

            fovUpDown.Value = (decimal)camera.Fov;

            jitteredRadioButton.Checked = rayTracer.Sampling == Vec2Sampling.Jittered;
            centerRadioButton.Checked = rayTracer.Sampling == Vec2Sampling.Dummy;
            randomRadioButton.Checked = rayTracer.Sampling == Vec2Sampling.Random;

            samplesUpDown.Value = rayTracer.Samples;

            updateUpDown.Value = rayTracer.SamplesRenderStep;

            gammaCheckBox.Checked = _controller.RayTracer.GammaCorrection;

            bloomUpDown.Value = rayTracer.Bloom;

            recLevelUpDown.Value = rayTracer.MaxDepth;

            recursionCheckbox.Checked = rayTracer is RecursionRayTracer;

            automaticCheckBox.Checked = _controller.AutomaticMode;

            if(camera is LensCamera lc)
            {
                lensRadiusUpDown.Value = (decimal)lc.LensRadius;
                focusDistanceUpDown.Value = (decimal)lc.FocusDistance;
                autoFocusCheckBox.Checked = lc.AutoFocus;
                lensCameraLayoutPanel.Visible = true;
            }
            else
            {
                lensCameraLayoutPanel.Visible = false;
            }
        }

        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1);

            ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.Bottom);
        }

        private void recursionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var previous = _controller.RayTracer;
            IncrementalRayTracer newRayTracer;
            if (recursionCheckbox.Checked)
                newRayTracer = new RecursionRayTracer(previous.MaxDepth, previous.Samples, previous.Sampling, previous.Resolution, previous.SamplesRenderStep);
            else
                newRayTracer = new SamplesRayTracer(previous.MaxDepth, previous.Samples, previous.Sampling, previous.Resolution, previous.SamplesRenderStep);

            newRayTracer.Bloom = previous.Bloom;
            newRayTracer.GammaCorrection = previous.GammaCorrection;
            _controller.RayTracer = newRayTracer;
        }

        private void bloomUpDown_ValueChanged(object sender, EventArgs e)
        {
            _controller.RayTracer.Bloom = (int)bloomUpDown.Value;
        }

        private void updateUpDown_ValueChanged(object sender, EventArgs e)
        {
            _controller.RayTracer.SamplesRenderStep = (int)updateUpDown.Value;
        }

        private void samplesUpDown_ValueChanged(object sender, EventArgs e)
        {
            _controller.RayTracer.Samples = (int)samplesUpDown.Value;
        }

        private void jitteredRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(jitteredRadioButton.Checked)
                _controller.RayTracer.Sampling = Vec2Sampling.Jittered;
        }

        private void centerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (centerRadioButton.Checked)
                _controller.RayTracer.Sampling = Vec2Sampling.Dummy;
        }

        private void randomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (randomRadioButton.Checked)
                _controller.RayTracer.Sampling = Vec2Sampling.Random;
        }

        private void fovUpDown_ValueChanged(object sender, EventArgs e)
        {
            _controller.Camera.Fov = (float)fovUpDown.Value;
        }

        private void UpdateCamera(Camera old, Camera newCamera)
        {
            newCamera.AspectRatio = old.AspectRatio;
            newCamera.Fov = old.Fov;
            newCamera.Pitch = old.Pitch;
            newCamera.Yaw = old.Yaw;
        }

        private void perspectiveCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(perspectiveCameraRadioButton.Checked)
            {
                lensCameraLayoutPanel.Visible = false;
                var previous = _controller.Camera;
                var newCamera = new PerspectiveCamera(previous.Position);
                _controller.Camera = newCamera;
                UpdateCamera(previous, newCamera);
            }
        }

        private void lensCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lensCameraRadioButton.Checked)
            {
                lensCameraLayoutPanel.Visible = true;
                var previous = _controller.Camera;
                var newCamera = new LensCamera(previous.Position);
                _controller.Camera = newCamera;
                lensRadiusUpDown.Value = (decimal)newCamera.LensRadius;
                focusDistanceUpDown.Value = (decimal)newCamera.FocusDistance;
                UpdateCamera(previous, newCamera);
            }
        }

        private void ortographicCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ortographicCameraRadioButton.Checked)
            {
                lensCameraLayoutPanel.Visible = false;
                var previous = _controller.Camera;
                var newCamera = new OrthographicCamera(previous.Position);
                _controller.Camera = newCamera;
                UpdateCamera(previous, newCamera);
            }
        }

        private void focusDistanceUpDown_ValueChanged(object sender, EventArgs e)
        {
            (_controller.Camera as LensCamera).FocusDistance = (float)focusDistanceUpDown.Value;
        }

        private void lensRadiusUpDown_ValueChanged(object sender, EventArgs e)
        {
            (_controller.Camera as LensCamera).LensRadius = (float)lensRadiusUpDown.Value;
        }

        private void recLevelUpDown_ValueChanged(object sender, EventArgs e)
        {
            _controller.RayTracer.MaxDepth = (int)recLevelUpDown.Value;
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void autoFocusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var camera = (_controller.Camera as LensCamera);
            if (camera != null)
            {
                camera.AutoFocus = autoFocusCheckBox.Checked;
            }
        }

        private void gammaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _controller.RayTracer.GammaCorrection = gammaCheckBox.Checked;
        }

        private void automaticCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _controller.AutomaticMode = automaticCheckBox.Checked;
        }
    }
}
