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
            }

            if (index == order.FindIndex(x => x == materialPanel) - 1) // next one is material panel (last panel)
            {
                makeNextButtonFinish();
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
            if (index == order.FindIndex(x => x == materialPanel)) // current one is material panel (last panel)
            {
                makeFinishButtonNext();
            }

            if (index > 0)
            {
                order[index - 1].Visible = true;
                order[index].Visible = false;
            }
        }

        private void makeNextButtonFinish()
        {
            nextButton.Click -= nextButton_Click;
            nextButton.Click += finishButton_Click;

            nextButton.Text = "Finish";
        }

        private void makeFinishButtonNext()
        {
            nextButton.Click += nextButton_Click;
            nextButton.Click -= finishButton_Click;

            nextButton.Text = "Next";
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