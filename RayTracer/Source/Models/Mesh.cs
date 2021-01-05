using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace RayTracing.Models
{
    public class Mesh
    {
        private List<int> vboIdList = new List<int>();
        private int vaoId;
        private int vertexCount;
        private const int POSITIONS_INDEX = 0;
        private const int NORMALS_INDEX = 1;
        private const int TEX_COORDS_INDEX = 2;
        public List<float> Positions;
        public List<float> Normals;
        public List<float> TexCoords;
        public List<int> Indices;

        public Mesh(List<float> positions, List<float> normals, List<float> texCoords, List<int> indices)
        {
            Positions = positions;
            Normals = normals;
            TexCoords = texCoords;
            Indices = indices;
        }

        public void Load()
        {
            vertexCount = Indices.Count;
            vaoId = GL.GenVertexArray();

            GL.BindVertexArray(vaoId);
            LoadDataBuffer(Positions, POSITIONS_INDEX, 3);
            LoadDataBuffer(Normals, NORMALS_INDEX, 3);
            if (TexCoords != null && TexCoords.Count > 0)
            {
                LoadDataBuffer(TexCoords, TEX_COORDS_INDEX, 2);
            }
            LoadIndexBuffer(Indices);
        }

        public void Unload()
        {
            foreach (var vbo in vboIdList)
            {
                GL.DeleteBuffer(vbo);
            }

            vboIdList.Clear();
            GL.DeleteVertexArray(vaoId);
            vaoId = 0;
        }

        private void LoadDataBuffer(List<float> buffer, int index, int size)
        {
            int vboId = GL.GenBuffer();
            vboIdList.Add(vboId);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboId);
            GL.BufferData(BufferTarget.ArrayBuffer,
                buffer.Count * sizeof(float),
                buffer.ToArray(),
                BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, size, VertexAttribPointerType.Float, false, 0, 0);
        }

        private void LoadIndexBuffer(List<int> buffer)
        {
            int vboId = GL.GenBuffer();
            vboIdList.Add(vboId);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vboId);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                buffer.Count * sizeof(int),
                buffer.ToArray(),
                BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        private void Init()
        {
            GL.BindVertexArray(vaoId);
        }

        private void End()
        {
            GL.BindVertexArray(0);
        }

        public void Render()
        {
            Init();
            GL.DrawElements(PrimitiveType.Triangles, vertexCount, DrawElementsType.UnsignedInt, 0);
            End();
        }

        public Vector3 GetPostion(int index)
        {
            float vx = Positions[3 * Indices[index] + 0];
            float vy = Positions[3 * Indices[index] + 1];
            float vz = Positions[3 * Indices[index] + 2];
            return new Vector3(vx, vy, vz);
        }

        public Vector3 GetNormal(int index)
        {
            float vx = Normals[3 * Indices[index] + 0];
            float vy = Normals[3 * Indices[index] + 1];
            float vz = Normals[3 * Indices[index] + 2];
            return new Vector3(vx, vy, vz);
        }

        public Vector2 GetTexCoord(int index)
        {
            if (TexCoords != null && TexCoords.Count > 2 * Indices[index] + 1)
            {
                float vx = TexCoords[2 * Indices[index] + 0];
                float vy = TexCoords[2 * Indices[index] + 1];
                return new Vector2(vx, vy);
            }
            return new Vector2();
        }
    }
}