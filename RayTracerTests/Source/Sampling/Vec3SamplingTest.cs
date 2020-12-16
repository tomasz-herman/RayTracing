using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using OpenTK;

namespace RayTracerTests.Source.Sampling
{
    public class Vec3Sampling
    {
        [Test]
        public void UniformSphereSamplesShouldLayWithinAUnitSphere()
        {
            List<Vector3> samplesOnSphere = RayTracing.Sampling.Vec3Sampling.UniformSphere(1000);

            samplesOnSphere.Should()
                .NotContain(sample => sample.Length > 1, "that would mean that sample is not within a unit sphere");
        }
    }
}