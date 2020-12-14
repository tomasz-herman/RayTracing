using FluentAssertions;
using OpenTK;

namespace RayTracerTests.Source
{
    public class TestUtils
    {
        public static void VectorsShouldBeApproximately(Vector3 vec1, Vector3 vec2, float precision)
        {
            vec1.X.Should().BeApproximately(vec2.X, precision);
            vec1.Y.Should().BeApproximately(vec2.Y, precision);
            vec1.Z.Should().BeApproximately(vec2.Z, precision);
        }
    }
}