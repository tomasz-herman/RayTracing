using System.Collections.Generic;
using System.IO;
using Assimp;
using Assimp.Configs;

namespace RayTracer.Models
{
    public class ModelLoader
    {
        private static void ProcessVertices(Assimp.Mesh mesh, List<float> vertices)
        {
            foreach (var v in mesh.Vertices)
            {
                vertices.Add(v.X);
                vertices.Add(v.Y);
                vertices.Add(v.Z);
            }
        }

        private static void ProcessTextCoord(Assimp.Mesh mesh, List<float> textCoord)
        {
            if (!mesh.HasTextureCoords(0)) return;
            foreach (var tc in mesh.TextureCoordinateChannels[0])
            {
                textCoord.Add(tc.X);
                textCoord.Add(1-tc.Y);
            }
        }

        private static void ProcessNormals(Assimp.Mesh mesh, List<float> normals)
        {
            foreach (var n in mesh.Normals)
            {
                normals.Add(n.X);
                normals.Add(n.Y);
                normals.Add(n.Z);
            }
        }

        private static void ProcessIndices(Assimp.Mesh mesh, List<int> indices)
        {
            foreach (var f in mesh.Faces)
            {
               foreach(var ind in f.Indices)
               {
                   indices.Add(ind);
               }
            }
        }

        private static Mesh ProcessMesh(Assimp.Scene scene, Assimp.Mesh mesh)
        {
            var positions = new List<float>();
            var textures = new List<float>();
            var normals = new List<float>();
            //List<float> tangents = new List<float>();
            //List<float> bitangens = new List<float>();
            var indices = new List<int>();

            //var material = processMaterial(scene, mesh);
            //System.Console.WriteLine(material.ToString());
            ProcessIndices(mesh, indices);
            ProcessNormals(mesh, normals);
            ProcessVertices(mesh, positions);
            ProcessTextCoord(mesh, textures);
            
            return new Mesh(positions, normals, textures, indices);
        }
        public static Model Load(string path, PostProcessSteps ppSteps, params PropertyConfig[] configs)
        {
            if(!File.Exists(path))
                return null;
            
            AssimpContext importer = new AssimpContext();
            if(configs != null)
            {
                foreach(PropertyConfig config in configs)
                    importer.SetConfig(config);
            }

            Scene scene = importer.ImportFile(path, ppSteps);
            if(scene == null)
                return null;

            var meshes = new List<Mesh>();
            for(int i = 0; i < scene.Meshes.Count; i++)
            {
                var m = ProcessMesh(scene, scene.Meshes[i]);
                meshes.Add(m);
            }

            Log.Info($"meshes loaded: {meshes.Count}");
            return new LoadedModel(meshes[0]);
        }
    }
}