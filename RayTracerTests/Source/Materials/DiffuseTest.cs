using FluentAssertions;
using NUnit.Framework;
using OpenTK.Graphics;
using RayTracing;
using RayTracing.Materials;
using RayTracing.Maths;

namespace RayTracerTests.Source.Materials
{
    public class DiffuseTest
    {
        [Test]
        public void DiffuseMaterialShouldPassItsColorWhenScatter()
        {
            Color albedo = Color.FromColor4(Color4.Beige);
            IMaterial diffuse = new Diffuse(albedo);
            HitInfo i = new HitInfo();
            Ray r = new Ray();

            diffuse.Scatter(ref r, ref i, out Color attenuation, out Ray ray);

            attenuation.Should().Be(albedo);
        }
    }
}