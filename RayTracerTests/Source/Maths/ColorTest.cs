using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using OpenTK.Graphics;
using RayTracer.Maths;

namespace RayTracerTests
{
    public class ColorTest
    {
        [Test]
        public void ColorsAdd()
        {
            Color first = new Color(0.25f, 0.25f, 0.25f);
            Color second = new Color(0.25f, 0.5f, 0.75f);
            Color expected = new Color(0.5f, 0.75f, 1f);

            Color result = first + second;

            result.Should().Be(expected);
        }
        
        [Test]
        public void ColorsMultiply()
        {
            Color right = new Color(0.25f, 0.25f, 0.25f);
            Color left = new Color(0.5f, 1f, 0f);
            Color expected = new Color(0.125f, 0.25f, 0f);

            Color result = right * left;

            result.Should().Be(expected);
        }
        
        [Test]
        public void ColorsMultiplyByScalar()
        {
            Color color = new Color(0.125f, 0.25f, 0.5f);
            float scalar = 2f;
            Color expected = new Color(0.25f, 0.5f, 1f);

            Color result = color * scalar;
            result.Should().Be(expected);
        }
        
        [Test]
        public void ColorsCanClampToItsRange()
        {
            Color color = new Color(-3f, 25f, 0.5f);
            Color expected = new Color(0, 1, 0.5f);

            color.Clamp();

            color.Should().Be(expected);
        }
        
        [Test]
        public void ColorsCanBeDisassembledToRgbByteValues()
        {
            Color color = new Color(0.2f, 0.4f, 0.8f);

            IEnumerable<byte> components = color.Components();

            components.Should().ContainInOrder(51, 102, 204).And.HaveCount(3);
        }

        [Test]
        public void ColorsCanMix()
        {
            Color red = new Color(1, 0, 0);
            Color blue = new Color(1, 0, 0);
            float mix = 0.6f;
            Color expected = new Color(0.6f, 0, 0.4f);

            Color mixed = Color.Mix(red, blue, mix);

            mixed.Should().Be(expected);
        }
        
        [Test]
        public void ColorsCanBeCreatedFromColor4()
        {
            Color4 red4 = Color4.Red;
            Color expected = new Color(1, 0, 0);
            
            Color red = Color.FromColor4(red4);
            
            red.Should().Be(expected);
        }
    }
}