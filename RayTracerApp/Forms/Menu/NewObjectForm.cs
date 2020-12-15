using System;
using System.Collections.Generic;
using RayTracerApp.Controls;
using RayTracerApp.SceneControllers;
using RayTracing.Models;

namespace RayTracerApp.Forms
{
    public partial class NewObjectForm : EditorForm
    {
        private readonly IController _controller;
        private IPanel _currentPanel;
        private List<IPanel> _order;

        public NewObjectForm(IController controller)
        {
            InitializeComponent();

            nextButton.Click += nextButton_Click;
            previousButton.Click += previousButton_Click;
            cancelButton1.Click += cancelButton_Click;
            cancelButton2.Click += cancelButton_Click;
            finishButton.Click += finishButton_Click;

            _controller = controller;

            _currentPanel = newModelPanel;
            _currentPanel.SetController(_controller);
            topLabel.Text = "Add new object...";
        }

        private void SetController()
        {
            foreach (var panel in _order) panel.SetController(_controller);
        }

        private void ChooseOrder()
        {
            switch (_controller.GetModel())
            {
                case Sphere sphere:
                    _order = new List<IPanel> {newModelPanel, positionPanel, materialPanel};
                    break;

                case Cube cube:
                    _order = new List<IPanel> {newModelPanel, positionPanel, materialPanel};
                    break;

                case CustomModel customModel:
                    _order = new List<IPanel> {newModelPanel, featuresPanel, positionPanel, materialPanel};
                    break;
            }
        }

        private void MoveNext()
        {
            var index = 0;
            if (_currentPanel != newModelPanel) index = _order.FindIndex(control => control == _currentPanel);

            if (index == 0)
            {
                ChooseOrder();
                SetController();
                cancelButton1.Visible = true;
                previousButton.Visible = true;
                cancelButton2.Visible = false;

                if (_controller.GetModel() is CustomModel)
                    topLabel.Text = "Add custom model...";
                else
                    topLabel.Text = $"Add {_controller.GetModel().GetType().Name.ToLower()}...";
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

            if (index == 1)
            {
                topLabel.Text = "Add new object...";

                cancelButton2.Visible = true;
                cancelButton1.Visible = false;
                previousButton.Visible = false;
            }

            if (index == _order.Count - 1)
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
            _controller.DeleteModel();
            _controller.Dispose();
            Close();
        }
    }
}