using System.Drawing;
using RayTracing.Materials;

namespace RayTracerApp.Utils
{
    public static class TextureConverter
    {
        public static Image Convert(Texture texture)
        {
            var result = new Bitmap(texture.Width, texture.Height);
            for (int i = 0; i < texture.Width; i++)
                for (int j = 0; j < texture.Height; j++)
                {
                    result.SetPixel(i, j, texture[i, j].ToSystemDrawing());
                }

            return result;
        }
    }
}