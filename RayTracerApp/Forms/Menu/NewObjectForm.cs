using System.Collections.Generic;
using System.Windows.Forms;

namespace RayTracerApp.Forms
{
    public partial class NewObjectForm : Form
    {
        private NewObjectController controller;
        private List<Control> order;

        public void SetController(NewObjectController controller)
        {
            this.controller = controller;
            newModelPanel.SetController(this.controller);
            positionPanel.SetController(this.controller);
            featuresPanel.SetController(this.controller);
            materialPanel.SetController(this.controller);

            order = new List<Control> {newModelPanel, featuresPanel, positionPanel, materialPanel};
        }

        public NewObjectForm()
        {
            InitializeComponent();
        }

        private void MoveNext()
        {
            var index = order.FindIndex(control => control.Visible);

            if (index == order.FindIndex(x => x == featuresPanel) - 1) // next one is features panel
            {
                featuresPanel.UpdateFeatures();

                button1.Visible = true;
                button2.Click += previousButton_Click;
                button2.Click -= cancelButton_Click;
                button2.Text = "Previous";

                topLabel.Text = $"Add new {controller.GetModel().GetType().Name.ToLower()}...";
            }

            if (index == order.FindIndex(x => x == materialPanel) - 1) // next one is material panel (last panel)
            {
                button3.Click -= nextButton_Click;
                button3.Click += finishButton_Click;
                button3.Text = "Finish";
            }

            if (index < order.Count - 1)
            {
                order[index + 1].Visible = true;
                order[index].Visible = false;
            }
        }

        private void MovePrevious()
        {
            var index = order.FindIndex(control => control.Visible);
            if(index == order.FindIndex(x => x == newModelPanel) + 1)
            {
                topLabel.Text = $"Add new object...";

                button1.Visible = false;
                button2.Click -= previousButton_Click;
                button2.Click += cancelButton_Click;
                button2.Text = "Cancel";
            }
            if (index == order.FindIndex(x => x == materialPanel)) // current one is material panel (last panel)
            {
                button3.Click += nextButton_Click;
                button3.Click -= finishButton_Click;
                button3.Text = "Next";
            }

            if (index > 0)
            {
                order[index - 1].Visible = true;
                order[index].Visible = false;
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