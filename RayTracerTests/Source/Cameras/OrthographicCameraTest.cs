using System;
using FluentAssertions;
using NUnit.Framework;
using OpenTK;
using RayTracing.Cameras;
using RayTracing.Maths;

namespace RayTracerTests.Source.Cameras
{
    public class OrthographicCameraTest
    {
        [Test]
        public void AllRaysDirectionIsSameAsCamerasFrontDirection()
        {
            Camera orthographic = new OrthographicCamera(Vector3.Zero);
            orthographic.Rotate(0, (float) Math.PI / 2, 0);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Ray ray = orthographic.GetRay((float) i / 10, (float) j / 10);
                    VectorsShouldBeApproximately(ray.Direction, new Vector3(1, 0, 0), Ray.Epsilon);
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