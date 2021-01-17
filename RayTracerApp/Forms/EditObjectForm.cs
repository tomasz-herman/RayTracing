using RayTracerApp.Panels;
using RayTracerApp.SceneController;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using Rectangle = RayTracing.Models.Rectangle;

namespace RayTracerApp.Forms
{
    public partial class EditObjectForm : ObjectForm
    {
        private readonly List<IPanelBase> _order;
        private IObjectController _controller;
        private IPanelBase _currentPanel;

        public EditObjectForm(IObjectController controller)
        {
            InitializeComponent();

            FormClosed += EditObjectForm_FormClosed;
            rightNextButton.Click += nextButton_Click;
            middlePreviousButton.Click += previousButton_Click;
            leftCancelButton.Click += cancelButton_Click;
            leftCancelButton.Text = "OK";
            middleCancelButton.Click += cancelButton_Click;
            middleCancelButton.Text = "OK";
            rightFinishButton.Click += finishButton_Click;

            _controller = controller;

            featuresPanel.Visible = false;
            positionPanel.Visible = false;
            materialPanel.Visible = false;

            var model = _controller.GetModel();
            var featureTypes = new List<Type> { typeof(Cylinder), typeof(Rectangle), typeof(Cuboid) };
            if (featureTypes.Contains(model.GetType()))
                _order = new List<IPanelBase> { featuresPanel, positionPanel, materialPanel };
            else
                _order = new List<IPanelBase> { positionPanel, materialPanel };

            _currentPanel = _order[0];
            _currentPanel.ShowPanel();

            SetController(controller);
            foreach(var panel in _order)
            {
                panel.UpdateFromModel();
            }

            topLabel.Text = String.Format(Properties.Strings.EditObjectMessage, _controller.GetModel().ToString().ToLower());
        }

        private void EditObjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _controller?.GetScene()?.Preprocess();
        }

        private void SetController(IObjectController controller)
        {
            _controller = controller;
            foreach (var panel in _order) panel.Controller = _controller;
        }

        private void MoveNext()
        {
            var index = _order.FindIndex(control => control == _currentPanel);

            if (index == 0)
            {
                leftCancelButton.Visible = true;
                middlePreviousButton.Visible = true;
                rightNextButton.Visible = true;

                middleCancelButton.Visible = false;

                rightNextButton.Focus();
            }

            if (index == _order.Count - 2)
            {
                rightFinishButton.Visible = true;

                rightNextButton.Visible = false;

                rightFinishButton.Focus();
            }

            if (index < _order.Count - 1)
            {
                _order[index + 1].ShowPanel();
                _order[index].HidePanel();
                _currentPanel = _order[index + 1];
            }
        }

        private void MovePrevious()
        {
            var index = _order.FindIndex(control => control == _currentPanel);

            if (index == _order.Count - 1)
            {

                leftCancelButton.Visible = true;
                middlePreviousButton.Visible = true;
                rightNextButton.Visible = true;

                middleCancelButton.Visible = false;
                rightFinishButton.Visible = false;

                middlePreviousButton.Focus();
            }

            if (index == 1)
            {
                rightNextButton.Visible = true;
                middleCancelButton.Visible = true;

                rightFinishButton.Visible = false;
                middlePreviousButton.Visible = false;
                leftCancelButton.Visible = false;

                middleCancelButton.Focus();
            }

            if (index > 0)
            {
                _order[index - 1].UpdateForModel();
                _order[index - 1].ShowPanel();
                _order[index].HidePanel();
                _currentPanel = _order[index - 1];
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            MoveNext();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
