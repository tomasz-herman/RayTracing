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

            order = new List<Control> { newModelPanel, positionPanel, featuresPanel };
        }
        public NewObjectForm()
        {
            InitializeComponent();
        }

        private void MoveNext()
        {
            var index = order.FindIndex(control => control.Visible);
            if(index == 1) // next one is features panel
            {
                featuresPanel.UpdateFeatures();
            }
            if(index < order.Count - 1)
            {
                order[index + 1].Visible = true;
                order[index].Visible = false;
            }
        }

        private void MovePrevious()
        {
            var index = order.FindIndex(control => control.Visible);
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

        private void previousButton_Click(object sender, System.EventArgs e)
        {
            MovePrevious();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            controller.Dispose();
            Close();
        }
    }
}