using System;
using System.Collections.Generic;
using RayTracerApp.Controls;
using RayTracerApp.SceneControllers;
using RayTracing.Models;

namespace RayTracerApp.Forms.Menu
{
    public partial class EditObjectForm : EditorForm
    {
        private readonly List<IPanel> order;
        private IController controller;
        private IPanel currentPanel;

        public EditObjectForm(IController controller)
        {
            InitializeComponent();

            nextButton.Click += nextButton_Click;
            previousButton.Click += previousButton_Click;
            cancelButton1.Click += cancelButton_Click;
            cancelButton2.Click += cancelButton_Click;
            finishButton.Click += finishButton_Click;

            this.controller = controller;

            switch (controller.GetModel())
            {
                case Sphere sphere:
                    order = new List<IPanel> {positionPanel, materialPanel};
                    currentPanel = positionPanel;
                    positionPanel.Visible = true;
                    break;

                case Cube cube:
                    order = new List<IPanel> {positionPanel, materialPanel};
                    currentPanel = positionPanel;
                    positionPanel.Visible = true;
                    break;
            }

            SetController(controller);
            currentPanel.UpdateForModel();
            if (controller.GetModel() is CustomModel)
                topLabel.Text = "Edit custom model...";
            else
                topLabel.Text = $"Edit {controller.GetModel().GetType().Name.ToLower()}...";
        }

        private void SetController(IController controller)
        {
            this.controller = controller;
            foreach (var panel in order) panel.SetController(this.controller);
        }

        private void MoveNext()
        {
            var index = order.FindIndex(control => control == currentPanel);

            if (index == 0)
            {
                cancelButton1.Visible = true;
                previousButton.Visible = true;
                cancelButton2.Visible = false;
            }

            if (index == order.Count - 2)
            {
                finishButton.Visible = true;
                nextButton.Visible = false;
            }

            if (index < order.Count - 1)
            {
                order[index + 1].UpdateForModel();
                order[index + 1].ShowPanel();
                order[index].HidePanel();
                currentPanel = order[index + 1];
            }
        }

        private void MovePrevious()
        {
            var index = order.FindIndex(control => control == currentPanel);

            if (index == order.Count - 1)
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
                order[index - 1].UpdateForModel();
                order[index - 1].ShowPanel();
                order[index].HidePanel();
                currentPanel = order[index - 1];
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            MoveNext();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            controller.Dispose();
            Close();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            controller.Dispose();
            Close();
        }
    }
}