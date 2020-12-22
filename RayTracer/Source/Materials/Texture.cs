﻿using System;
using System.IO;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using RayTracing.Maths;
using StbImageSharp;
using StbImageWriteSharp;
using ColorComponents = StbImageSharp.ColorComponents;

namespace RayTracing.Materials
{
    public class Texture : ITexture, IDisposable
    {
        private const string TexturesPath = "RayTracer.Resources.Textures.";
        private int _id;
        private Color[,] _data;

        public int Width => _data.GetLength(1);
        public int Height => _data.GetLength(0);
        public int Id => _id;

        public Texture(int width, int height)
        {
            _data = new Color[height, width];
        }

        public Texture(Texture image) // copy constructor
        {
            _data = new Color[image.Height, image.Width];
            for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                _data[i, j] = image._data[i, j];
        }

        public Texture(string path)
        {
            Log.Info($"Loading texture from path: {path}");
            Stream stream;
            if(Path.IsPathRooted(path))
                stream = File.OpenRead(path);
            else
            {
                var assembly = GetType().Assembly;
                stream = assembly.GetManifestResourceStream(TexturesPath+path);
            }
            LoadFromStream(stream);
            LoadGLTexture();
            stream.Dispose();
        }

        public Color this[float u, float v]
        {
            get => _data[(int)(u * (Height-1)), (int)((1-v) * (Width-1))];
        }

        public Color this[int w, int h]
        {
            get => _data[h, w];
            set => _data[h, w] = value;
        }

        public void Process(Func<Color, Color> function)
        {
            for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                _data[i, j] = function(_data[i, j]);
        }

        private void LoadFromStream(Stream stream)
        {
            ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlue);
            _data = new Color[image.Width, image.Height];
            for (int i = 0; i < image.Width * image.Height; ++i)
            {
                byte r = image.Data[i * 3];
                byte g = image.Data[i * 3 + 1];
                byte b = image.Data[i * 3 + 2];
                _data[i % image.Width, i / image.Width] = new Color(r / 255f, g / 255f, b / 255f);
            }
        }

        public byte[] RawData()
        {
            byte[] raw = new byte[Width * Height * 3];

            for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
            {
                Color color = _data[Height - i - 1, j];
                raw[i * Width * 3 + j * 3 + 0] = color.RComp;
                raw[i * Width * 3 + j * 3 + 1] = color.GComp;
                raw[i * Width * 3 + j * 3 + 2] = color.BComp;
            }

            return raw;
        }

        public void Write(string path)
        {
            byte[] raw = RawData();
            using Stream stream = File.OpenWrite(path);
            ImageWriter writer = new ImageWriter();
            writer.WritePng(raw, Width, Height, StbImageWriteSharp.ColorComponents.RedGreenBlue, stream);
        }

        public void LoadGLTexture()
        {
            byte[] raw = RawData();
            _id = GL.GenTexture();
            Use();
            GL.TexImage2D(TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                Width,
                Height,
                0,
                PixelFormat.Rgb,
                PixelType.UnsignedByte,
                raw);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapR, (int) TextureWrapMode.Repeat);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            Clear();
        }

        private static void Use(int id, TextureUnit unit = TextureUnit.Texture0)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, id);
        }

        public void Use(TextureUnit unit = TextureUnit.Texture0)
        {
            Use(_id, unit);
        }

        public static void Clear(TextureUnit unit = TextureUnit.Texture0)
        {
            Use(0, unit);
        }

        public void Blit()
        {
            LoadGLTexture();
            int fboId = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.ReadFramebuffer, fboId);
            GL.FramebufferTexture2D(FramebufferTarget.ReadFramebuffer, FramebufferAttachment.ColorAttachment0,
                TextureTarget.Texture2D, Id, 0);
            GL.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);
            GL.BlitFramebuffer(0, 0, Width, Height, 0, 0, Width, Height,
                ClearBufferMask.ColorBufferBit, BlitFramebufferFilter.Nearest);
        }

        public void Dispose()
        {
            GL.DeleteTexture(_id);
            _data = null;
        }
    }
}