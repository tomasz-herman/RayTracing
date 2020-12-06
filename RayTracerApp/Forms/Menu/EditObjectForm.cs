using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Forms.Menu
{
    public partial class EditObjectForm : EditorForm
    {
        private EditObjectController controller;

        public EditObjectForm()
        {
            InitializeComponent();
            
        }

        public void SetController(EditObjectController controller)
        {
            this.controller = controller;
            this.featuresPanel.SetController(this.controller);
            this.materialPanel.SetController(this.controller);
            this.positionPanel.SetController(this.controller);
        }
    }
}
