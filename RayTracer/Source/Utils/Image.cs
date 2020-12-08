using System;
using System.IO;
using RayTracing.Maths;
using StbImageWriteSharp;

namespace RayTracing.Utils
{
    public class Image
    {
        private readonly Color[,] _data;
        public int Width => _data.GetLength(1);
        public int Height => _data.GetLength(0);

        public Image(int width, int height)
        {
            _data = new Color[height, width];
        }

        public Image(Image image) // copy constructor
        {
            _data = new Color[image.Width, image.Height];
            for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                _data[i, j] = image._data[i, j];
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
            writer.WritePng(raw, Width, Height, ColorComponents.RedGreenBlue, stream);
        }
    }
}