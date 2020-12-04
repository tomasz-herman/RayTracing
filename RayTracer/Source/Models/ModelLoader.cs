using System.Collections.Generic;
using System.IO;
using Assimp;
using Assimp.Configs;

namespace RayTracing.Models
{
    public class ModelLoader
    {
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

        private static Mesh ProcessMesh(Scene scene, Assimp.Mesh mesh)
        {
            var positions = ProcessVertices(mesh);
            var textures = ProcessTextCoord(mesh);
            var normals = ProcessNormals(mesh);
            var indices = ProcessIndices(mesh);

            return new Mesh(positions, normals, textures, indices);
        }

        public static Model Load(string path, PostProcessSteps ppSteps, params PropertyConfig[] configs)
        {
            if (!File.Exists(path))
                return null;

            AssimpContext importer = new AssimpContext();
            if (configs != null)
            {
                foreach (PropertyConfig config in configs)
                    importer.SetConfig(config);
            }

            Scene scene = importer.ImportFile(path, ppSteps);
            if (scene == null)
                return null;

            var meshes = new List<Mesh>();
            for (int i = 0; i < scene.Meshes.Count; i++)
            {
                var m = ProcessMesh(scene, scene.Meshes[i]);
                meshes.Add(m);
            }

            Log.Info($"meshes loaded: {meshes.Count}");
            return new CustomModel(meshes[0]);
        }
    }
}