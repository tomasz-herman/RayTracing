using RayTracer.Models;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class NewModelPanel : UserControl
    {
        private NewObjectController _controller;
        public void SetController(NewObjectController newObjectController)
        {
            _controller = newObjectController;
        }
        public NewModelPanel()
        {
            InitializeComponent();
        }

        private void RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            var rand = new System.Random();
            if (rb.Checked)
            {
                if(rb.Text == "Sphere")
                {
                    _controller.SetModel(new Sphere { 
                        Position = new OpenTK.Vector3(0),
                        Scale = 1
                    }
                    );
                }
            }
        }
    }
}