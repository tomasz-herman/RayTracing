using RayTracerApp.SceneController;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Panels.FeaturesPanels
{
    public partial class CustomModelFeature : UserControl, IPanelBase
    {
        public CustomModelFeature()
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

        private void customModelButton_Click(object sender, EventArgs e)
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

                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var model = ModelLoader.Load(filePath);
                    Controller.GetModel()?.Unload();
                    Controller.SetModel(model, true);
                    Controller.GetModel().Load();
                    Controller.UpdateModelFromUI();
                    predefinedModelComboBox.ResetText();
                }
            }
        }

        private void predefinedModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selected = "";
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    selected = "birch_tree";
                    break;
                case 1:
                    selected = "mountain";
                    break;
                case 2:
                    selected = "mug";
                    break;
                case 3:
                    selected = "lamp";
                    break;
                case 4:
                    selected = "tank";
                    break;
                case 5:
                    selected = "teapot";
                    break;
                case 6:
                    selected = "trex";
                    break;
                default:
                    throw new Exception("Wrong argument");
            }
            selected = selected + ".dae";
            var model = ModelLoader.Load(selected, true);
            Controller.GetModel()?.Unload();
            Controller.SetModel(model, true);
            Controller.GetModel().Load();
            Controller.UpdateModelFromUI();
        }
    }
}
