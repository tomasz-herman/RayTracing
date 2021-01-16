using RayTracerApp.SceneController;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rectangle = RayTracing.Models.Rectangle;

namespace RayTracerApp.Panels
{
    public partial class ObjectSelectionPanel : UserControl, IPanelBase
    {
        public ObjectSelectionPanel()
        {
            InitializeComponent();
        }

        public IObjectController Controller { get; set; }

        public void UpdateForModel()
        {
        }

        public void UpdateFromModel()
        {
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            if (rb.Checked)
            {
                switch (rb.TabIndex)
                {
                    case 0:
                        Controller.SetModel(new Sphere().Load());
                        break;
                    case 1:
                        Controller.SetModel(new Cuboid().Load());
                        break;
                    case 2:
                        Controller.SetModel(new Cylinder().Load());
                        break;
                    case 3:
                        Controller.SetModel(new Plane().Load());
                        break;
                    case 4:
                        Controller.SetModel(new Rectangle(1f).Load());
                        break;
                    case 5:
                        Controller.SetModel(new CustomModel());
                        break;
                }
                Controller.UpdateModelFromUI();
            }
        }
    }
}
