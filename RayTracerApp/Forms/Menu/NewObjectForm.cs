using System;
using System.Collections.Generic;
using RayTracerApp.Controls;
using RayTracerApp.SceneControllers;
using RayTracing.Models;

namespace RayTracerApp.Forms
{
    public partial class NewObjectForm : EditorForm
    {
        private readonly IController controller;
        private IPanel currentPanel;
        private List<IPanel> order;

        public NewObjectForm(IController controller)
        {
            InitializeComponent();

            nextButton.Click += nextButton_Click;
            previousButton.Click += previousButton_Click;
            cancelButton1.Click += cancelButton_Click;
            cancelButton2.Click += cancelButton_Click;
            finishButton.Click += finishButton_Click;

            this.controller = controller;

            currentPanel = newModelPanel;
            currentPanel.SetController(this.controller);
            topLabel.Text = "Add new object...";
        }

        private void SetController()
        {
            foreach (var panel in order) panel.SetController(controller);
        }

        private void ChooseOrder()
        {
            switch (controller.GetModel())
            {
                case Sphere sphere:
                    order = new List<IPanel> {newModelPanel, positionPanel, materialPanel};
                    break;

                case Cube cube:
                    order = new List<IPanel> {newModelPanel, positionPanel, materialPanel};
                    break;

                case CustomModel customModel:
                    order = new List<IPanel> {newModelPanel, featuresPanel, positionPanel, materialPanel};
                    break;
            }
        }

        private void MoveNext()
        {
            var index = 0;
            if (currentPanel != newModelPanel) index = order.FindIndex(control => control == currentPanel);

            if (index == 0)
            {
                ChooseOrder();
                SetController();
                cancelButton1.Visible = true;
                previousButton.Visible = true;
                cancelButton2.Visible = false;

                if (controller.GetModel() is CustomModel)
                    topLabel.Text = "Add custom model...";
                else
                    topLabel.Text = $"Add {controller.GetModel().GetType().Name.ToLower()}...";
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

            if (index == 1)
            {
                topLabel.Text = "Add new object...";

                cancelButton2.Visible = true;
                cancelButton1.Visible = false;
                previousButton.Visible = false;
            }

            if (index == order.Count - 1)
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
            controller.DeleteModel();
            controller.Dispose();
            Close();
        }
    }
}