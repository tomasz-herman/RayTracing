using System;
using FluentAssertions;
using NUnit.Framework;
using OpenTK;
using RayTracing.Cameras;
using RayTracing.Maths;

namespace RayTracerTests.Source.Cameras
{
    public class PerspectiveCameraTest
    {
        [Test]
        public void AllRaysStartAtCameraPosition()
        {
            Camera perspective = new PerspectiveCamera(Vector3.One);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Ray ray = perspective.GetRay((float) i / 10, (float) j / 10);
                    VectorsShouldBeApproximately(ray.Origin, Vector3.One, Ray.Epsilon);
                }
            }
        }
        
        
        static void VectorsShouldBeApproximately(Vector3 vec1, Vector3 vec2, float precision)
        {
            vec1.X.Should().BeApproximately(vec2.X, precision);
            vec1.Y.Should().BeApproximately(vec2.Y, precision);
            vec1.Z.Should().BeApproximately(vec2.Z, precision);
        }
    }
}