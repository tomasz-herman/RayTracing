using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Assimp;
using Assimp.Configs;
using RayTracing.Materials;
using RayTracing.Maths;

namespace RayTracing.Models
{
    public class ModelLoader
    {
        private const string ModelsPath = "RayTracer.Resources.Models.";
        
        public static CustomModel Load(string path, bool loadFromExe = false)
        {
            return Load(path,
                PostProcessSteps.Triangulate |
                PostProcessSteps.GenerateNormals |
                PostProcessSteps.JoinIdenticalVertices |
                PostProcessSteps.FixInFacingNormals, 
                loadFromExe);
        }

        public static CustomModel Load(string path, PostProcessSteps ppSteps, bool loadFromExe = false, params PropertyConfig[] configs)
        {
            Log.Info($"Loading model: {path}");

            var model = new CustomModel();

            if (!File.Exists(path) && !loadFromExe)
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
                Scene scene;
                if (loadFromExe)
                {
                    var assembly = Assembly.GetAssembly(typeof(ModelLoader));
                    Stream stream = assembly.GetManifestResourceStream(ModelsPath + path);
                    scene = importer.ImportFileFromStream(stream, ppSteps, Path.GetExtension(path));
                    stream.Dispose();
                }
                else
                {
                    scene = importer.ImportFile(path, ppSteps);
                }
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

                var mesh = new Mesh(new List<float>(), new List<float>(), new List<float>(), new List<int>());
                for (int i = 0; i < scene.MeshCount; i++)
                {
                    mesh += ProcessMesh(scene.Meshes[i]);
                }

                var material = ProcessMaterial(scene.Materials[scene.Meshes[0].MaterialIndex],
                    loadFromExe ? "" : Path.GetDirectoryName(Path.GetFullPath(path)));

                model.SetMesh(mesh);
                model.Material = material;

                return model;
            }
            catch (AssimpException e)
            {
                Log.Error("Assimp has thrown an exception.", e);
                Console.WriteLine(e.Message);
                return model;
            }
        }

        private static IMaterial ProcessMaterial(Assimp.Material material, string dir)
        {
            Log.Info($"Processing material:: {material.Name}");
            return new MasterMaterial
            {
                Emissive =
                {
                    Albedo = ProcessTexture(material.HasTextureAmbient, material.ColorAmbient,
                        material.TextureAmbient, dir)
                },
                Diffuse =
                {
                    Albedo = ProcessTexture(material.HasTextureDiffuse, material.ColorDiffuse,
                        material.TextureDiffuse, dir)
                },
                Reflective =
                {
                    Albedo =
                        ProcessTexture(material.HasTextureSpecular, material.ColorSpecular,
                            material.TextureSpecular, dir),
                    Disturbance = Math.Min(Math.Max(1 - material.ShininessStrength / 100, 0), 1)
                },
                Parts = ProcessMaterialParts(material.ColorAmbient, material.ColorDiffuse, material.ColorSpecular)
            };
        }

        private static ITexture ProcessTexture(bool hasTexture, Color4D color4, TextureSlot textureSlot, string dir)
        {
            Log.Info($"Processing texture:: hasTex:{hasTexture}, Color: {color4}, Texture:{textureSlot.FilePath}");
            return hasTexture
                ? (ITexture) new Texture(Path.Combine(dir, textureSlot.FilePath))
                : new SolidColor(Color.FromAssimpColor4(color4));
        }

        private static (float emissive, float diffuse, float reflective, float refractive) ProcessMaterialParts(
            Color4D ambient, Color4D diffuse, Color4D specular)
        {
            (float emissive, float diffuse, float reflective, float refractive) parts =
                (Color.FromAssimpColor4(ambient).GetBrightness(), Color.FromAssimpColor4(diffuse).GetBrightness(),
                    Color.FromAssimpColor4(specular).GetBrightness(), 0);
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