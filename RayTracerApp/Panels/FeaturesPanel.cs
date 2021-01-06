using RayTracerApp.SceneController;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Panels
{
    public partial class FeaturesPanel : UserControl, IPanelBase
    {
        public FeaturesPanel()
        {
            InitializeComponent();
        }

        public IObjectController Controller { get; set; }

        public void UpdateForModel()
        {
            var model = Controller.GetModel();
            switch (model)
            {
                case Rectangle rectangle:
                    rectangle.AspectRatio = (float)aspectRatioUpDown.Value;
                    break;
                case Cylinder cylinder:
                    cylinder.Aspect = (float)aspectRatioUpDown.Value;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }

        public void UpdateFromModel()
        {
            var model = Controller.GetModel();
            switch (model)
            {
                case Rectangle rectangle:
                    aspectRatioUpDown.Value = (decimal)rectangle.AspectRatio;
                    break;
                case Cylinder cylinder:
                    aspectRatioUpDown.Value = (decimal)cylinder.Aspect;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
        }

        private void aspectRatioUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var model = Controller.GetModel();
            switch(model)
            {
                case Rectangle rectangle:
                    rectangle.AspectRatio = val;
                    break;
                case Cylinder cylinder:
                    cylinder.Aspect = val;
                    break;
                default:
                    throw new Exception("Bad model type");
            }
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
                    Controller.SetModel(model);
                    Controller.GetModel().Load();
                }
            }
        }

        private void FeaturesPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (Controller == null) return;
            var model = Controller.GetModel();
            bool customModel = model is CustomModel && !(model is Cube);
            filePanel.Visible = customModel;
            aspectPanel.Visible = !customModel;
        }
    }
}
