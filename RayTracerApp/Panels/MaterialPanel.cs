using RayTracerApp.SceneController;
using RayTracerApp.Utils;
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
            // done in Controller SetModel()
        }

        public void UpdateFromModel()
        {
            var material = Controller.Material;
            if (material.Diffuse.Albedo is Texture)
                diffuseTexture.Image = TextureConverter.Convert(material.Diffuse.Albedo as Texture);
            else
            {
                diffuseTexture.BackColor = material.Diffuse.Albedo[0, 0].ToSystemDrawing();
                diffuseTexture.Image = null;
            }

            if (material.Emissive.Albedo is Texture)
                emissiveTexture.Image = TextureConverter.Convert(material.Emissive.Albedo as Texture);
            else
            {
                emissiveTexture.BackColor = material.Emissive.Albedo[0, 0].ToSystemDrawing();
                emissiveTexture.Image = null;
            }

            if (material.Reflective.Albedo is Texture)
                reflectiveTexture.Image = TextureConverter.Convert(material.Reflective.Albedo as Texture);
            else
            {
                reflectiveTexture.BackColor = material.Reflective.Albedo[0, 0].ToSystemDrawing();
                reflectiveTexture.Image = null;
            }

            if (material.Refractive.Albedo is Texture)
                refractiveTexture.Image = TextureConverter.Convert(material.Refractive.Albedo as Texture);
            else
            {
                refractiveTexture.BackColor = material.Refractive.Albedo[0, 0].ToSystemDrawing();
                refractiveTexture.Image = null;
            }

            refractiveIndexUpDown.Value = (decimal)material.Refractive.RefractiveIndex;
            reflectiveDisturbanceUpDown.Value = (decimal)material.Reflective.Disturbance;
            diffuseShareUpDown.Value = (decimal)material.Parts.diffuse;
            reflectiveShareUpDown.Value = (decimal)material.Parts.reflective;
            refractiveShareUpDown.Value = (decimal)material.Parts.refractive;
            emissiveShareUpDown.Value = (decimal)material.Parts.emissive;
            ampUpDown.Value = (decimal)material.Emissive.Amplification;
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

            var texture = new Texture(texturePath);
            Controller.Material.Diffuse.Albedo = texture;
            diffuseTexture.Image = TextureConverter.Convert(texture);
        }

        private void emissiveFile_Click(object sender, EventArgs e)
        {
            var texturePath = ChooseTexture();
            if (string.IsNullOrEmpty(texturePath)) return;

            var texture = new Texture(texturePath);
            Controller.Material.Emissive.Albedo = texture;
            emissiveTexture.Image = TextureConverter.Convert(texture);
        }

        private void reflectiveFile_Click(object sender, EventArgs e)
        {
            var texturePath = ChooseTexture();
            if (string.IsNullOrEmpty(texturePath)) return;

            var texture = new Texture(texturePath);
            Controller.Material.Reflective.Albedo = texture;
            reflectiveTexture.Image = TextureConverter.Convert(texture);
        }

        private void refractiveFile_Click(object sender, EventArgs e)
        {
            var texturePath = ChooseTexture();
            if (string.IsNullOrEmpty(texturePath)) return;

            var texture = new Texture(texturePath);
            Controller.Material.Refractive.Albedo = texture;
            refractiveTexture.Image = TextureConverter.Convert(texture);
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
                diffuseTexture.Image = null;

                Controller.Material.Diffuse.Albedo = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }

        private void emissiveColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                emissiveTexture.BackColor = color;
                emissiveTexture.Image = null;
                Controller.Material.Emissive.Albedo = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }

        private void reflectiveColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                reflectiveTexture.BackColor = color;
                reflectiveTexture.Image = null;
                Controller.Material.Reflective.Albedo = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }

        private void refractiveColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                refractiveTexture.BackColor = color;
                refractiveTexture.Image = null;
                Controller.Material.Refractive.Albedo = new SolidColor(RayTracing.Maths.Color.FromSystemDrawing(color));
            }
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1);

            ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.Bottom);
        }

        private void ampUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            float val = (float)nud.Value;

            Controller.Material.Emissive.Amplification = val;
        }
    }
}
