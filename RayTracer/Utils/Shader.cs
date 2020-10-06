using System;
using System.IO;
using System.Text;
using OpenTK.Graphics.ES30;

namespace RayTracer.Utils
{
    class Shader
    {
        private const string ShadersPath = "RayTracer.Shaders.";
        private readonly int _handle;

        public Shader(string vertexPath, string fragmentPath)
        {
            Log.Info($"Loading shader {vertexPath}, {fragmentPath}");
            string vertexShaderSource = ReadShaderFromFile(vertexPath);
            string fragmentShaderSource = ReadShaderFromFile(fragmentPath);

            var vertexShaderId = CompileShader(vertexShaderSource, ShaderType.VertexShader);
            var fragmentShaderId = CompileShader(fragmentShaderSource, ShaderType.FragmentShader);

            _handle = LinkShader(vertexShaderId, fragmentShaderId);
        }

        private string ReadShaderFromFile(string shaderName)
        {
            var assembly = typeof(Program).Assembly;
            using Stream vertexShaderStream = assembly.GetManifestResourceStream(ShadersPath+shaderName);
            using StreamReader reader = new StreamReader(vertexShaderStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private int CompileShader(string shaderSource, ShaderType shaderType)
        {
            int shaderId = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderId, shaderSource);

            GL.CompileShader(shaderId);

            string infoLogVert = GL.GetShaderInfoLog(shaderId);
            if (!String.IsNullOrEmpty(infoLogVert))
                Log.Error(infoLogVert);

            return shaderId;
        }

        private int LinkShader(int vertexShaderId, int fragmentShaderId)
        {
            int handle = GL.CreateProgram();

            GL.AttachShader(handle, vertexShaderId);
            GL.AttachShader(handle, fragmentShaderId);

            GL.LinkProgram(handle);

            GL.DetachShader(handle, vertexShaderId);
            GL.DetachShader(handle, fragmentShaderId);
            GL.DeleteShader(fragmentShaderId);
            GL.DeleteShader(vertexShaderId);

            return handle;
        }

        public void Use()
        {
            GL.UseProgram(_handle);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(_handle);

                disposedValue = true;
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(_handle);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}