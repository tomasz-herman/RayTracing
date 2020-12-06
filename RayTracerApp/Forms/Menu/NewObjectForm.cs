using RayTracerApp.Controls;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RayTracerApp.Forms
{
    public partial class NewObjectForm : EditorForm
    {
        private IController controller;
        private List<IPanel> order;
        private IPanel currentPanel;

        public NewObjectForm(IController controller)
        {
            InitializeComponent();

            button3.Click += nextButton_Click;
            button2.Click += cancelButton_Click;
            button1.Click += cancelButton_Click;

            this.controller = controller;

            currentPanel = newModelPanel;
            currentPanel.SetController(this.controller);
            topLabel.Text = $"Add new object...";
        }

        private void SetController()
        {
            foreach (var panel in order)
            {
                panel.SetController(this.controller);
            }
        }

        private void ChooseOrder()
        {
            switch (controller.GetModel())
            {
                case Sphere sphere:
                    order = new List<IPanel> { newModelPanel, positionPanel, materialPanel };
                    break;

                case Cube cube:
                    order = new List<IPanel> { newModelPanel, positionPanel, materialPanel };
                    break;
            }
        }

        private void MoveNext()
        {
            var index = 0;
            if(currentPanel != newModelPanel)
            {
                index = order.FindIndex(control => control == currentPanel);
            }

            if (index == 0)
            {
                ChooseOrder();
                SetController();
                button1.Visible = true;
                button2.Click += previousButton_Click;
                button2.Click -= cancelButton_Click;
                button2.Text = "Previous";

                topLabel.Text = $"Add new {controller.GetModel().GetType().Name.ToLower()}...";
            }

            if (index == order.Count-2)
            {
                button3.Click -= nextButton_Click;
                button3.Click += finishButton_Click;
                button3.Text = "Finish";
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
                topLabel.Text = $"Add new object...";

                button1.Visible = false;
                button2.Click -= previousButton_Click;
                button2.Click += cancelButton_Click;
                button2.Text = "Cancel";
            }
            if (index == order.Count-1) // current one is material panel (last panel)
            {
                button3.Click += nextButton_Click;
                button3.Click -= finishButton_Click;
                button3.Text = "Next";
            }

            if (index > 0)
            {
                order[index - 1].UpdateForModel();
                order[index - 1].ShowPanel();
                order[index].HidePanel();
                currentPanel = order[index - 1];
            }
        }

        private void nextButton_Click(object sender, System.EventArgs e)
        {
            MoveNext();
        }

        private void finishButton_Click(object sender, System.EventArgs e)
        {
            controller.Dispose();
            Close();
        }

        private void previousButton_Click(object sender, System.EventArgs e)
        {
            MovePrevious();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            controller.DeleteModel();
            controller.Dispose();
            Close();
        }
    }
}