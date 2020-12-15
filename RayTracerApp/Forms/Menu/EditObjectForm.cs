using System;
using System.Collections.Generic;
using RayTracerApp.Controls;
using RayTracerApp.SceneControllers;
using RayTracing.Models;

namespace RayTracerApp.Forms.Menu
{
    public partial class EditObjectForm : EditorForm
    {
        private readonly List<IPanel> _order;
        private IController _controller;
        private IPanel _currentPanel;

        public EditObjectForm(IController controller)
        {
            InitializeComponent();

            nextButton.Click += nextButton_Click;
            previousButton.Click += previousButton_Click;
            cancelButton1.Click += cancelButton_Click;
            cancelButton2.Click += cancelButton_Click;
            finishButton.Click += finishButton_Click;

            _controller = controller;

            switch (controller.GetModel())
            {
                case Sphere sphere:
                    _order = new List<IPanel> {positionPanel, materialPanel};
                    _currentPanel = positionPanel;
                    positionPanel.Visible = true;
                    break;

                case Cube cube:
                    _order = new List<IPanel> {positionPanel, materialPanel};
                    _currentPanel = positionPanel;
                    positionPanel.Visible = true;
                    break;
            }

            SetController(controller);
            _currentPanel.UpdateForModel();
            if (_controller.GetModel() is CustomModel)
                topLabel.Text = "Edit custom model...";
            else
                topLabel.Text = $"Edit {_controller.GetModel().GetType().Name.ToLower()}...";
        }

        private void SetController(IController controller)
        {
            _controller = controller;
            foreach (var panel in _order) panel.SetController(_controller);
        }

        private void MoveNext()
        {
            var index = _order.FindIndex(control => control == _currentPanel);

            if (index == 0)
            {
                cancelButton1.Visible = true;
                previousButton.Visible = true;
                cancelButton2.Visible = false;
            }

            if (index == _order.Count - 2)
            {
                finishButton.Visible = true;
                nextButton.Visible = false;
            }

            if (index < _order.Count - 1)
            {
                _order[index + 1].UpdateForModel();
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
                cancelButton2.Visible = true;
                cancelButton1.Visible = false;
                previousButton.Visible = false;
            }

            if (index == 1)
            {
                nextButton.Visible = true;
                finishButton.Visible = false;
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
            _controller.Dispose();
            Close();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _controller.Dispose();
            Close();
        }
    }
}