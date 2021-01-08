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
using Rectangle = RayTracing.Models.Rectangle;

namespace RayTracerApp.Forms
{
    public partial class NewObjectForm : ObjectForm
    {
        private IObjectController _controller;
        private IPanelBase _currentPanel;
        private List<IPanelBase> _order;
        public NewObjectForm(IObjectController controller)
        {
            InitializeComponent();

            rightNextButton.Click += nextButton_Click;
            middlePreviousButton.Click += previousButton_Click;
            leftCancelButton.Click += cancelButton_Click;
            middleCancelButton.Click += cancelButton_Click;
            rightFinishButton.Click += finishButton_Click;

            _controller = controller;
            objectSelectionPanel.Visible = true;
            featuresPanel.Visible = false;
            positionPanel.Visible = false;
            materialPanel.Visible = false;

            _currentPanel = objectSelectionPanel;
            _currentPanel.Controller = _controller;
            topLabel.Text = "Add new object...";
            SetController();

            controller.UpdateModelFromUI = () => {
                ChooseOrder();
                UpdateForModel();
                materialPanel.UpdateFromModel();
            };
            ChooseOrder();
            foreach(var panel in _order)
            {
                panel.UpdateFromModel();
            }
        }

        private void SetController()
        {
            objectSelectionPanel.Controller = _controller;
            featuresPanel.Controller = _controller;
            positionPanel.Controller = _controller;
            materialPanel.Controller = _controller;
        }

        private void ChooseOrder()
        {
            var model = _controller.GetModel();
            var featureTypes = new List<Type> { typeof(Cylinder), typeof(Rectangle), typeof(CustomModel) };
            if (featureTypes.Contains(model.GetType()))
                _order = new List<IPanelBase> { objectSelectionPanel, featuresPanel, positionPanel, materialPanel };
            else
                _order = new List<IPanelBase> { objectSelectionPanel, positionPanel, materialPanel };
        }

        private void UpdateForModel()
        {
            foreach(var panel in _order)
            {
                panel.UpdateForModel();
            }
        }

        private void MoveNext()
        {
            var index = 0;
            if (_currentPanel != objectSelectionPanel) index = _order.FindIndex(control => control == _currentPanel);

            if (index == 0)
            {
                leftCancelButton.Visible = true;
                middlePreviousButton.Visible = true;

                middleCancelButton.Visible = false;

                rightNextButton.Focus();

                topLabel.Text = $"Add {_controller.GetModel().ToString().ToLower()}...";
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

            if (index == 1)
            {
                topLabel.Text = "Add new object...";

                middleCancelButton.Visible = true;

                leftCancelButton.Visible = false;
                middlePreviousButton.Visible = false;

                middleCancelButton.Focus();
            }

            if (index == _order.Count - 1)
            {
                rightNextButton.Visible = true;

                rightFinishButton.Visible = false;

                middlePreviousButton.Focus();
            }

            if (index > 0)
            {
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
            _controller.GetScene().Preprocess();
            Close();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _controller.DeleteModel();
            Close();
        }
    }
}
