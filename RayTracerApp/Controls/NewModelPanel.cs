using RayTracing.Models;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    public partial class NewModelPanel : UserControl
    {
        private NewObjectController controller;

        public void SetController(NewObjectController newObjectController)
        {
            controller = newObjectController;
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

            if (rb.Checked)
            {
                if (rb.Text == "Sphere")
                {
                    controller.SetModel(new Sphere
                        {
                            Position = new OpenTK.Vector3(0),
                            Scale = 1
                        }.Load()
                    );
                }
            }
        }
    }
}