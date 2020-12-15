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
        private IController _controller;

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
            _controller = controller;
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
                openFileDialog.Filter =
                    "All types|*.fbx;*.dae;*.gltf;*.glb;*.blend;*.3ds;*.ase;*.obj;*.ifc;*.xgl;*.zgl;*.ply;*.lwo;*.lws;*.lxo;*.stl;*.x;*.ac;*.ms3d|" +
                    "Autodesk (*.fbx)|*.fbx|" +
                    "Collada (*.dae)|*.dae|" +
                    "glTF (*.gltf, *.glb)|*.gltf;*.glb|" +
                    "Blender 3D (*.blend)|*.blend|" +
                    "3ds Max 3DS (*.3ds)|*.3ds|" +
                    "3ds Max ASE (*.ase)|*.ase|" +
                    "Wavefront Object (*.obj)|*.obj|" +
                    "Industry Foundation Classes (IFC/Step) (*.ifc)|*.ifc|" +
                    "XGL (*.xgl, *.zgl)|*.xgl;*.zgl|" +
                    "Stanford Polygon Library (*.ply)|*.ply|" +
                    "LightWave (*.lwo)|*.lwo|" +
                    "LightWave Scene (*.lws)|*.lws|" +
                    "Modo (*.lxo)|*.lxo|" +
                    "Stereolithography (*.stl)|*.stl|" +
                    "DirectX X (*.x)|*.x|" +
                    "AC3D (*.ac)|*.ac|" +
                    "Milkshape 3D (*.ms3d)|*.ms3d";
        
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var mesh = ModelLoader.LoadMesh(filePath, Assimp.PostProcessSteps.Triangulate);
                    (_controller.GetModel() as CustomModel).SetMesh(mesh);
                    _controller.GetModel().Load();
                }
            }
        }
    }
}
