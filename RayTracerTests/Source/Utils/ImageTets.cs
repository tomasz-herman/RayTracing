using System;
using NUnit.Framework;
using RayTracer.Utils;
using FluentAssertions;
using RayTracer.Maths;

namespace RayTracerTests
{
    public class ImageTets
    {
        [Test]
        public void HeightOfNewImageIsConsistentWithConstructorParameter()
        {
            Image image;
            const int width = 3;
            const int height = 5;
                
            image = new Image(width, height);

            image.Height.Should().Be(height);
        }
        
        [Test]
        public void WidthOfNewImageIsConsistentWithConstructorParameter()
        {
            Image image;
            const int width = 3;
            const int height = 5;
                
            image = new Image(width, height);

            image.Width.Should().Be(width);
        }
        
        [Test]
        public void AccessingPixelOutsideOfImageShouldThrowOutRangeException()
        {
            const int width = 3;
            const int height = 5;
            Image image = new Image(width, height);
            
            Action action = () =>
            {
                Color c = image[width, height - 1];
            };

            action.Should().Throw<IndexOutOfRangeException>();
        }
        
        [Test]
        public void IndexingOperatorCanChangeValues()
        {
            Image image;
            const int width = 1;
            const int height = 1;
            image = new Image(width, height);
            Color violet = new Color(1, 0, 1);

            image[0, 0] = violet;

            image[0, 0].Should().Be(violet);
        }
        
        [Test]
        public void NewImageIsBlack()
        {
            Image image;
                
            image = new Image(3, 2);

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    image[j, i].Should().Be(new Color(0, 0, 0));
                }
            }
        }
    }
}