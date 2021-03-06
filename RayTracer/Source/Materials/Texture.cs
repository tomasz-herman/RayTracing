﻿using System;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using RayTracing.Maths;
using RayTracing.Shaders;
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

        public int Width => _data.GetLength(0);
        public int Height => _data.GetLength(1);
        public int Id => _id;

        public Color[,] Data
        {
            get => _data;
            set
            {
                _data = value;
                LoadGLTexture();
            }
        }

        public Texture()
        {
        }

        public Texture(int width, int height)
        {
            _data = new Color[width, height];
        }

        public Texture(Texture image) // copy constructor
        {
            _data = new Color[image.Width, image.Height];
            for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                _data[i, j] = image._data[i, j];
        }

        public Texture(string path, bool glLoad = true)
        {
            Log.Info($"Loading texture from path: {path}");
            Stream stream;
            if (Path.IsPathRooted(path))
                stream = File.OpenRead(path);
            else
            {
                var assembly = GetType().Assembly;
                stream = assembly.GetManifestResourceStream(TexturesPath + path);
            }

            LoadFromStream(stream);
            if (glLoad) LoadGLTexture();
            stream.Dispose();
        }

        public Color this[float u, float v]
        {
            get
            {
                if (u < 0 || u > 1 || v < 0 || v > 1)
                {
                    u -= (float) Math.Floor(u);
                    v -= (float) Math.Floor(v);
                }

                return _data[(int) (u * (Width - 1)), (int) (v * (Height - 1))];
            }
        }

        public Color this[int w, int h]
        {
            get => _data[w, h];
            set => _data[w, h] = value;
        }

        public void CopyFrom(Texture texture)
        {
            if (this.Width != texture.Width || this.Height != texture.Height) return;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    this[i, j] = texture[i, j];
                }
            }
        }

        public void Bloom(Color color, int w, int h, int brightness, int strength = 1)
        {
            if (strength == 0 || brightness <= 1) return;

            brightness *= strength;

            bool In(int x, int y)
            {
                return x >= 0 && x < Width && y >= 0 && y < Height;
            }

            for (int i = -brightness; i < brightness; i++)
            for (int j = -brightness; j < brightness; j++)
            {
                if (In(w + i, h + j) && i != 0 && j != 0)
                {
                    int rs = i * i + j * j;
                    if (rs <= brightness * brightness)
                        _data[w + i, h + j] += color * strength * strength / (10 * brightness * (rs + 1));
                }
            }
        }

        public static Texture operator *(Texture texture, float multiplier)
        {
            var res = new Texture(texture);
            res.Process(color => color * multiplier);
            return res;
        }

        public void Process(Func<Color, Color> function)
        {
            for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                _data[i, j] = function(_data[i, j]);
        }

        public void AutoGammaCorrect()
        {
            float sum = 0;
            for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                sum += _data[i, j].GetBrightness();
            float brightness = sum / (Width * Height);
            float correction = 2.0f - 1.5f * brightness;
            Log.Info(
                $"Auto gamma correcting image. Calculated average brightness: {brightness}, applying correction: {correction}.");
            Process(c => c.GammaCorrection(correction));
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

            for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
            {
                Color color = _data[i, j];
                raw[j * Width * 3 + i * 3 + 0] = color.RComp;
                raw[j * Width * 3 + i * 3 + 1] = color.GComp;
                raw[j * Width * 3 + i * 3 + 2] = color.BComp;
            }

            return raw;
        }

        public byte[] FlippedRawData()
        {
            byte[] raw = new byte[Width * Height * 3];

            for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
            {
                Color color = _data[i, j];
                raw[(Height - j - 1) * Width * 3 + i * 3 + 0] = color.RComp;
                raw[(Height - j - 1) * Width * 3 + i * 3 + 1] = color.GComp;
                raw[(Height - j - 1) * Width * 3 + i * 3 + 2] = color.BComp;
            }

            return raw;
        }

        public void Write(string path)
        {
            byte[] raw = FlippedRawData();
            using Stream stream = File.OpenWrite(path);
            ImageWriter writer = new ImageWriter();
            writer.WritePng(raw, Width, Height, StbImageWriteSharp.ColorComponents.RedGreenBlue, stream);
        }

        public void LoadGLTexture(TextureUnit unit = TextureUnit.Texture0)
        {
            byte[] raw = RawData();
            _id = GL.GenTexture();
            Use(unit);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
            GL.TexImage2D(TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgb,
                Width,
                Height,
                0,
                PixelFormat.Rgb,
                PixelType.UnsignedByte,
                raw);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Repeat);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            Clear(unit);
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

        public void Use(Shader shader, int matNum, float part)
        {
            shader.SetInt(ITexture.MaterialUseColorUniformName(matNum), 0);
            Use(ITexture.MaterialTextureUnit(matNum));
            shader.SetFloat(ITexture.MaterialPartUniformName(matNum), part);
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