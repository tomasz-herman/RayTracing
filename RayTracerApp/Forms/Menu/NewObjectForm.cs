using System.Windows.Forms;

namespace RayTracerApp.Forms
{
    public partial class NewObjectForm : Form
    {
        private NewObjectController _controller;

        public void SetController(NewObjectController controller)
        {
            _controller = controller;
            newModelPanel.SetController(_controller);
            positionPanel.SetController(_controller);
        }
        public NewObjectForm()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, System.EventArgs e)
        {
            if (newModelPanel.Visible)
            {
                newModelPanel.Visible = false;
                positionPanel.Visible = true;
            }
        }

        private void previousButton_Click(object sender, System.EventArgs e)
        {
            if (positionPanel.Visible)
            {
                newModelPanel.Visible = true;
                positionPanel.Visible = false;
            }
            
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}