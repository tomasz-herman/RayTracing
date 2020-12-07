using System;
using NUnit.Framework;
using FluentAssertions;
using RayTracing.Materials;
using RayTracing.Maths;

namespace RayTracerTests
{
    public class TextureTets
    {
        [Test]
        public void HeightOfNewTextureIsConsistentWithConstructorParameter()
        {
            Texture image;
            const int width = 3;
            const int height = 5;
                
            image = new Texture(width, height);

            image.Height.Should().Be(height);
        }
        
        [Test]
        public void WidthOfNewTextureIsConsistentWithConstructorParameter()
        {
            Texture image;
            const int width = 3;
            const int height = 5;
                
            image = new Texture(width, height);

            image.Width.Should().Be(width);
        }
        
        [Test]
        public void AccessingPixelOutsideOfTextureShouldThrowOutRangeException()
        {
            const int width = 3;
            const int height = 5;
            Texture image = new Texture(width, height);
            
            Action action = () =>
            {
                Color c = image[width, height - 1];
            };

            action.Should().Throw<IndexOutOfRangeException>();
        }
        
        [Test]
        public void IndexingOperatorCanChangeValues()
        {
            Texture image;
            const int width = 1;
            const int height = 1;
            image = new Texture(width, height);
            Color violet = new Color(1, 0, 1);

            image[0, 0] = violet;

            image[0, 0].Should().Be(violet);
        }
        
        [Test]
        public void NewTextureIsBlack()
        {
            Texture image;
                
            image = new Texture(3, 2);

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    image[j, i].Should().Be(new Color(0, 0, 0));
                }
            }
        }
        
        [Test]
        public void TexturesAreDeepCopied()
        {
            Texture image = new Texture(1, 1);
            image[0, 0] = new Color(1, 0, 0);
            
            Texture copy = new Texture(image);
            image[0, 0] = new Color(0, 1, 1);

            copy[0, 0].Should().Be(new Color(1, 0, 0));
        }
        
        [Test]
        public void RawDataShouldHaveRGBOrder()
        {
            Texture image = new Texture(1, 1)
            {
                [0, 0] = new Color(0.25f, 0.5f, 0.75f)
            };

            byte[] raw = image.RawData();

            raw.Should().ContainInOrder(63, 127, 191);
        }


        [Test]
        public void RawDataShouldContainRowByRowFlippedInYAxis()
        {
            Texture image = new Texture(3, 2)
            {
                [0, 1] = new Color(1.0f / 255.0f, 2.0f / 255.0f, 3.0f / 255.0f),
                [1, 1] = new Color(4.0f / 255.0f, 5.0f / 255.0f, 6.0f / 255.0f),
                [2, 1] = new Color(7.0f / 255.0f, 8.0f / 255.0f, 9.0f / 255.0f),
                [0, 0] = new Color(10.0f / 255.0f, 11.0f / 255.0f, 12.0f / 255.0f),
                [1, 0] = new Color(13.0f / 255.0f, 14.0f / 255.0f, 15.0f / 255.0f),
                [2, 0] = new Color(16.0f / 255.0f, 17.0f / 255.0f, 18.0f / 255.0f)
            };

            byte[] raw = image.RawData();

            raw.Should().ContainInOrder(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18);
        }
        
        [Test]
        public void WriteShouldSaveTextureToPngFile()
        {
            const string path = "WriteShouldSaveTextureToPngFile.png";
            Texture image = new Texture(3, 2)
            {
                [0, 1] = new Color(1.0f / 255.0f, 2.0f / 255.0f, 3.0f / 255.0f),
                [1, 1] = new Color(4.0f / 255.0f, 5.0f / 255.0f, 6.0f / 255.0f),
                [2, 1] = new Color(7.0f / 255.0f, 8.0f / 255.0f, 9.0f / 255.0f),
                [0, 0] = new Color(10.0f / 255.0f, 11.0f / 255.0f, 12.0f / 255.0f),
                [1, 0] = new Color(13.0f / 255.0f, 14.0f / 255.0f, 15.0f / 255.0f),
                [2, 0] = new Color(16.0f / 255.0f, 17.0f / 255.0f, 18.0f / 255.0f)
            };

            image.Write(path);

            FileAssert.Exists(path);
        }
    }
}