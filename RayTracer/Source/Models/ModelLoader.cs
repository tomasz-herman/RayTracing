using System.Collections.Generic;
using System.IO;
using Assimp;
using Assimp.Configs;
using RayTracing.Materials;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class ModelLoader
    {
        public static CustomModel Load(string path)
        {
            return Load(path,
                PostProcessSteps.Triangulate |
                PostProcessSteps.GenerateNormals |
                PostProcessSteps.JoinIdenticalVertices |
                PostProcessSteps.EmbedTextures |
                PostProcessSteps.FixInFacingNormals);
        }

        public static CustomModel Load(string path, PostProcessSteps ppSteps, params PropertyConfig[] configs)
        {
            Log.Info($"Loading model: {path}");

            var model = new CustomModel();

            if (!File.Exists(path))
            {
                Log.Error($"Model {path} does not exist.");
                return model;
            }

            var importer = new AssimpContext();
            if (configs != null)
            {
                foreach (var config in configs)
                    importer.SetConfig(config);
            }

            try
            {
                var scene = importer.ImportFile(path, ppSteps);
                if (scene == null)
                {
                    Log.Error($"Error loading model {path}. Scene was null.");
                    return model;
                }

                if (scene.Meshes.Count == 0)
                {
                    Log.Error($"Error loading model {path}. No meshes found.");
                    return model;
                }
                
                if (scene.Meshes.Count > 1)
                {
                    Log.Warn($"Model {path} containing more than one mesh. Using first mesh.");
                }

                var mesh = ProcessMesh(scene.Meshes[0]);
                var material = ProcessMaterial(scene.Materials[scene.Meshes[0].MaterialIndex]);

                model.SetMesh(mesh);
                model.Material = material;
                
                return model;
            }
            catch (AssimpException e)
            {
                Log.Error("Assimp has thrown an exception.", e);
                return model;
            }
        }

        private static IMaterial ProcessMaterial(Assimp.Material material)
        {
            Emissive emissive = new Emissive(ProcessTexture(material.HasTextureAmbient, material.ColorAmbient,
                material.TextureAmbient));
            Diffuse diffuse = new Diffuse(ProcessTexture(material.HasTextureDiffuse, material.ColorDiffuse,
                material.TextureDiffuse));
            Reflective reflective = new Reflective(ProcessTexture(material.HasColorSpecular, material.ColorSpecular,
                material.TextureSpecular));

            // MasterMaterial material = new MasterMaterial();
            // material.Emissive.Emit =
            //     ProcessTexture(material.HasTextureAmbient, material.ColorAmbient, material.TextureAmbient);
            // material.Diffuse.Albedo =
            //     ProcessTexture(material.HasTextureDiffuse, material.ColorDiffuse, material.TextureDiffuse);
            // material.Reflective.Albedo =
            //     ProcessTexture(material.HasColorSpecular, material.ColorSpecular, material.TextureSpecular);
            // material.Parts = ProcessMaterialParts(material.ColorAmbient, material.ColorDiffuse, material.ColorSpecular);
            //
            // return material;

            return diffuse;
        }

        private static ITexture ProcessTexture(bool hasTexture, Color4D color4, TextureSlot textureSlot)
        {
            return hasTexture
                ? (ITexture) new Texture(textureSlot.FilePath)
                : new SolidColor(Color.FromAssimpColor4(color4));
        }

        private static (float emissive, float diffuse, float reflective, float refractive) ProcessMaterialParts(
            Color4D ambient, Color4D diffuse, Color4D specular)
        {
            (float emissive, float diffuse, float reflective, float refractive) parts =
                (Color.FromAssimpColor4(ambient).GetBrightness(), Color.FromAssimpColor4(diffuse).GetBrightness(),
                    Color.FromAssimpColor4(specular).GetBrightness(), 0);

            float sum = parts.emissive + parts.diffuse + parts.reflective;
            if (sum != 0)
            {
                parts.emissive /= sum;
                parts.diffuse /= sum;
                parts.reflective /= sum;
            }

            return parts;
        }

        private static Mesh ProcessMesh(Assimp.Mesh mesh)
        {
            var positions = ProcessVertices(mesh);
            var textures = ProcessTextCoord(mesh);
            var normals = ProcessNormals(mesh);
            var indices = ProcessIndices(mesh);

            return new Mesh(positions, normals, textures, indices);
        }

        private static List<float> ProcessVertices(Assimp.Mesh mesh)
        {
            List<float> vertices = new List<float>();
            foreach (var v in mesh.Vertices)
            {
                vertices.Add(v.X);
                vertices.Add(v.Y);
                vertices.Add(v.Z);
            }

            return vertices;
        }

        private static List<float> ProcessTextCoord(Assimp.Mesh mesh)
        {
            List<float> textCoord = new List<float>();
            if (mesh.HasTextureCoords(0))
                foreach (var tc in mesh.TextureCoordinateChannels[0])
                {
                    textCoord.Add(tc.X);
                    textCoord.Add(1 - tc.Y);
                }

            return textCoord;
        }

        private static List<float> ProcessNormals(Assimp.Mesh mesh)
        {
            List<float> normals = new List<float>();
            foreach (var n in mesh.Normals)
            {
                normals.Add(n.X);
                normals.Add(n.Y);
                normals.Add(n.Z);
            }

            return normals;
        }

        private static List<int> ProcessIndices(Assimp.Mesh mesh)
        {
            List<int> indices = new List<int>();
            foreach (var f in mesh.Faces)
            {
                foreach (var ind in f.Indices)
                {
                    indices.Add(ind);
                }
            }

            return indices;
        }
    }
}