using System;
using System.IO;
using OpenTK.Graphics.OpenGL;
using RayTracer.Maths;
using StbImageSharp;

namespace RayTracer.Materials
{
    public class Texture
    {
        private int id;
        private Color[,] data;

        public Texture(String path)
        {
            Log.Info($"Loading texture from path: {path}");
            using var stream = File.OpenRead(path);
            ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
            byte[] data = image.Data;
            this.data = new Color[image.Width,image.Height];
            for (int i = 0; i < image.Width*image.Height; ++i)
            {
                byte r = data[i*4];
                byte g = data[i*4 + 1];
                byte b = data[i*4 + 2];
                this.data[i%image.Width,i/image.Width]=new Color(r/255f,g/255f,b/255f);
            }

            id = LoadGLTexture(image);
        }

        private static int LoadGLTexture(ImageResult image)
        {
            int id = GL.GenTexture(); 
            Use(id);
            GL.TexImage2D(TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                image.Width,
                image.Height,
                0,
                PixelFormat.Rgba,
                PixelType.UnsignedByte,
                image.Data);
                
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapR, (int)TextureWrapMode.Repeat);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            
            Clear();

            return id;
        }

        private static void Use(int id, TextureUnit unit = TextureUnit.Texture0)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, id);
        }
        
        public void Use(TextureUnit unit = TextureUnit.Texture0)
        {
            Use(id, unit);
        }
        
        public static void Clear(TextureUnit unit = TextureUnit.Texture0)
        {
            Use(0, unit);
        }
    }
}