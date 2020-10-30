using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace RayTracer.Models
{
    public class Mesh
    {
        private List<int> vboIdList = new List<int>();
        private int vaoId;
        private int vertexCount;

        public Mesh(List<float> positions, List<int> indices)
        {
            vertexCount = indices.Count;
            vaoId = GL.GenVertexArray();

            GL.BindVertexArray(vaoId);
            
            int vboId = GL.GenBuffer();
            vboIdList.Add(vboId);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboId);
            GL.BufferData(BufferTarget.ArrayBuffer, 
                positions.Count * sizeof(float), 
                positions.ToArray(), 
                BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            
            vboId = GL.GenBuffer();
            vboIdList.Add(vboId);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vboId);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                indices.Count * sizeof(int),
                indices.ToArray(),
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