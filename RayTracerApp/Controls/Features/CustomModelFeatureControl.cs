using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using RayTracerApp.SceneControllers;

namespace RayTracerApp.Controls.Features
{
    public partial class CustomModelFeatureControl : UserControl, IPanel
    {
        private IController controller;

        public CustomModelFeatureControl()
        {
            InitializeComponent();
        }

        public void HidePanel()
        {
            Visible = false;
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        public void ShowPanel()
        {
            Visible = true;
        }

        public void UpdateForModel()
        {
            
        }

        private void loadFromFileButton_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "../..");
                openFileDialog.Filter = "obj files (*.obj)|*.obj";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    var mesh = ModelLoader.LoadMesh(filePath, Assimp.PostProcessSteps.Triangulate);
                    (controller.GetModel() as CustomModel).SetMesh(mesh);
                    controller.GetModel().Load();
                }
            }
        }
    }
}
