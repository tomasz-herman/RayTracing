using RayTracerApp.SceneController;
using RayTracing.Materials;
using RayTracing.Maths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RayTracerApp.Panels
{
    public partial class MaterialPanel : UserControl, IPanelBase
    {
        public MaterialPanel()
        {
            InitializeComponent();
        }

        public IObjectController Controller { get; set; }

        public void UpdateForModel()
        {
            
        }

        public void UpdateFromModel()
        {
            var material = Controller.Material;
            refractiveIndexUpDown.Value = (decimal)material.Refractive.RefractiveIndex;
            reflectiveDisturbanceUpDown.Value = (decimal)material.Reflective.Disturbance;
            diffuseShareUpDown.Value = (decimal)material.Parts.diffuse;
            reflectiveShareUpDown.Value = (decimal)material.Parts.reflective;
            refractiveShareUpDown.Value = (decimal)material.Parts.refractive;
            emissiveShareUpDown.Value = (decimal)material.Parts.emissive;
        }

        private string ChooseTexture()
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "../..");
                openFileDialog.Filter =
                    "All types|*.jpg;*.jpeg;*.png;*.bmp;*.tga|" +
                    "jpg (*.jpg, *.jpeg)|*.jpg;*.jpeg|" +
                    "png (*.png)|*.png|" +
                    "bmp (*.bmp)|*.bmp|" +
                    "tga (*.tga)|*.tga";

                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
        }

        private void diffuseFile_Click(object sender, EventArgs e)
        {
            var texturePath = ChooseTexture();
            if (string.IsNullOrEmpty(texturePath)) return;

            Controller.Material.Diffuse.Albedo = new Texture(texturePath);
            diffuseTexture.BackColor = this.BackColor;
            diffuseTexture.Text = texturePath.Split(Path.DirectorySeparatorChar)[^1];
        }

        private void emissiveFile_Click(object sender, EventArgs e)
        {
            var texturePath = ChooseTexture();
            if (string.IsNullOrEmpty(texturePath)) return;

            Controller.Material.Emissive.Emit = new Texture(texturePath);
            emissiveTexture.BackColor = this.BackColor;
            emissiveTexture.Text = texturePath.Split(Path.DirectorySeparatorChar)[^1];
        }

        private void reflectiveFile_Click(object sender, EventArgs e)
        {
            var texturePath = ChooseTexture();
            if (string.IsNullOrEmpty(texturePath)) return;

            Controller.Material.Reflective.Albedo = new Texture(texturePath);
            reflectiveTexture.BackColor = this.BackColor;
            reflectiveTexture.Text = texturePath.Split(Path.DirectorySeparatorChar)[^1];
        }

        private void refractiveFile_Click(object sender, EventArgs e)
        {
            var texturePath = ChooseTexture();
            if (string.IsNullOrEmpty(texturePath)) return;

            Controller.Material.Refractive.Albedo = new Texture(texturePath);
            refractiveTexture.BackColor = this.BackColor;
            refractiveTexture.Text = texturePath.Split(Path.DirectorySeparatorChar)[^1];
        }

        private void diffuseShareUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var parts = Controller.Material.Parts;
            parts.diffuse = val;
            Controller.Material.Parts = parts;
        }

        private void emissiveShareUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var parts = Controller.Material.Parts;
            parts.emissive = val;
            Controller.Material.Parts = parts;
        }

        private void reflectiveShareUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var parts = Controller.Material.Parts;
            parts.reflective = val;
            Controller.Material.Parts = parts;
        }

        private void reflectiveDisturbanceUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            Controller.Material.Reflective.Disturbance = val;
        }

        private void refractiveShareUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            var parts = Controller.Material.Parts;
            parts.refractive = val;
            Controller.Material.Parts = parts;
        }

        private void refractiveIndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            Controller.Material.Refractive.RefractiveIndex = val;
        }

        private void diffuseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                diffuseTexture.BackColor = color;
                diffuseTexture.Text = "      ";


                Controller.Material.Diffuse.Albedo = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }

        private void emissiveColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                emissiveTexture.BackColor = color;
                emissiveTexture.Text = "      ";
                Controller.Material.Emissive.Emit = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }

        private void reflectiveColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                reflectiveTexture.BackColor = color;
                reflectiveTexture.Text = "      ";
                Controller.Material.Reflective.Albedo = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }

        private void refractiveColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                refractiveTexture.BackColor = color;
                refractiveTexture.Text = "      ";
                Controller.Material.Refractive.Albedo = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }
    }
}
