using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace RayTracer.Models
{
    public class Mesh
    {
        private List<int> vboIdList = new List<int>();
        private int vaoId;
        private int vertexCount;
        public const int POSITIONS_INDEX = 0;
        public const int NORMALS_INDEX = 1;
        public const int TEX_COORDS_INDEX = 2;

        public Mesh(List<float> positions,List<float> normals,List<float> texCoords, List<int> indices)
        {
            vertexCount = indices.Count;
            vaoId = GL.GenVertexArray();

            GL.BindVertexArray(vaoId);
            LoadDataBuffer(positions, POSITIONS_INDEX, 3);
            LoadDataBuffer(normals, NORMALS_INDEX, 3);
            LoadDataBuffer(texCoords, TEX_COORDS_INDEX, 2);
            LoadIndexBuffer(indices);
        }

        public void LoadDataBuffer(List<float> buffer, int index, int size)
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

        public void LoadIndexBuffer(List<int> buffer)
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
        
        public void Init()
        {
            GL.BindVertexArray(vaoId);
        }

        public void End()
        {
            GL.BindVertexArray(0);
        }

        public void Render()
        {
            Init();
            GL.DrawElements(PrimitiveType.Triangles, vertexCount, DrawElementsType.UnsignedInt, 0);
            End();
        }
    }
}