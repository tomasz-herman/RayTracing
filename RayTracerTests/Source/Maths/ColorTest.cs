using FluentAssertions;
using NUnit.Framework;
using RayTracer.Maths;

namespace RayTracerTests
{
    public class ColorTest
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void ColorsAdd()
        {
            Color first = new Color(0.25f, 0.25f, 0.25f);
            Color second = new Color(0.25f, 0.5f, 0.75f);
            Color expected = new Color(0.5f, 0.75f, 1f);

            Color result = first + second;

            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void ColorsMultiply()
        {
            Color right = new Color(0.25f, 0.25f, 0.25f);
            Color left = new Color(0.5f, 1f, 0f);
            Color expected = new Color(0.125f, 0.25f, 0f);

            Color result = right * left;

            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void ColorsMultiplyByScalar()
        {
            Color color = new Color(0.125f, 0.25f, 0.5f);
            float scalar = 2f;
            Color expected = new Color(0.25f, 0.5f, 1f);

            Color result = color * scalar;
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void ColorsCanClampToItsRange()
        {
            Color color = new Color(-3f, 25f, 0.5f);
            Color expected = new Color(0, 1, 0.5f);

            color.Clamp();

            color.Should().Be(expected);
        }
    }
}