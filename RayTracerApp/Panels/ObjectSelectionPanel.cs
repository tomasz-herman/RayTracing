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
                switch (rb.Text)
                {
                    case "Sphere":
                        Controller.SetModel(new Sphere().Load());
                        break;
                    case "Cuboid":
                        Controller.SetModel(new Cuboid().Load());
                        break;
                    case "Cylinder":
                        Controller.SetModel(new Cylinder().Load());
                        break;
                    case "Plane":
                        Controller.SetModel(new Plane().Load());
                        break;
                    case "Rectangle":
                        Controller.SetModel(new Rectangle(1f).Load());
                        break;
                    case "Custom model":
                        Controller.SetModel(new CustomModel());
                        break;
                }
                Controller.UpdateModelFromUI();
            }
        }
    }
}
