using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics.ES30;

namespace RayTracer.Utils
{
    public class Shader
    {
        private const string ShadersPath = "RayTracer.Resources.Shaders.";
        private readonly int _handle;

        public Shader(string vertexPath, string fragmentPath)
        {
            Log.Info($"Loading shader {vertexPath}, {fragmentPath}");
            string vertexShaderSource = ReadShaderFromFile(vertexPath);
            string fragmentShaderSource = ReadShaderFromFile(fragmentPath);

            var vertexShaderId = CompileShader(vertexShaderSource, ShaderType.VertexShader);
            var fragmentShaderId = CompileShader(fragmentShaderSource, ShaderType.FragmentShader);
            _handle = LinkShader(vertexShaderId, fragmentShaderId);
            GL.GetProgram(_handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
            
            _uniformLocations = new Dictionary<string, int>();
            
            for (var i = 0; i < numberOfUniforms; i++)
            {
                var key = GL.GetActiveUniform(_handle, i, out _, out _);
                var location = GL.GetUniformLocation(_handle, key);
                _uniformLocations.Add(key, location);
            }
        }

        private string ReadShaderFromFile(string shaderName)
        {
            var assembly = typeof(Program).Assembly;
            using Stream vertexShaderStream = assembly.GetManifestResourceStream(ShadersPath+shaderName);
            using StreamReader reader = new StreamReader(vertexShaderStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private static int CompileShader(string shaderSource, ShaderType shaderType)
        {
            int shaderId = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderId, shaderSource);

            GL.CompileShader(shaderId);
            string infoLogVert = GL.GetShaderInfoLog(shaderId);
            if (!string.IsNullOrEmpty(infoLogVert))
                Log.Error(infoLogVert);
    
            return shaderId;
        }

        private static int LinkShader(int vertexShaderId, int fragmentShaderId)
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

        public void SetMatrix4(string name, Matrix4 data)
        {
            GL.UseProgram(_handle);
            GL.UniformMatrix4(_uniformLocations[name], true, ref data);
        }

        public void Use()
        {
            GL.UseProgram(_handle);
        }

        private bool isDisposed = false;
        private Dictionary<string, int> _uniformLocations;

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            GL.DeleteProgram(_handle);
            isDisposed = true;
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