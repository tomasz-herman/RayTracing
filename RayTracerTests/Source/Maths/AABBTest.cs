using System;
using FluentAssertions;
using NUnit.Framework;
using OpenTK;
using RayTracing.Maths;

namespace RayTracerTests
{
    public class AABBTest
    {
        [Test]
        public void AABBsCanAdd()
        {
            AABB first = new AABB(-1, -1, -1, 1, 1, 1);
            AABB second = new AABB(-2, -2, -2,0, 0, 0);

            AABB result = first + second;

            result.Should().BeEquivalentTo(new AABB(-2, -2, -2, 1, 1, 1));
        }
        
        [Test]
        public void ConstructorThrowsExceptionIfMinIsGreaterThanMax()
        {
            Action action = () =>
            {
                AABB aabb = new AABB(1, 1, 1, 0, 0, 0);
            };

            action.Should().Throw<ArgumentException>();
        }
        
        [TestCaseSource(nameof(AABBHitCases))]
        public void AABBShouldBeHit(AABB aabb, Ray impactRay, float to)
        {
            bool hit = aabb.Test(ref impactRay, 0, to);

            hit.Should().BeTrue();
        }

        static object[] AABBHitCases =
        {
            new object[]
            {
                new AABB(-1, -1, -1, 1, 1, 1), 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = -Vector3.UnitZ
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new AABB(-1, -1, -1, 1, 1, 1), 
                new Ray
                {
                    Origin = Vector3.Zero, 
                    Direction = -Vector3.UnitZ
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new AABB(2, 2, 2, 4, 4, 4), 
                new Ray
                {
                    Origin = Vector3.Zero, 
                    Direction = Vector3.One
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new AABB(200, 200, 200, 201, 201, 201), 
                new Ray
                {
                    Origin = Vector3.Zero, 
                    Direction = Vector3.One
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new AABB(200, 200, 200, 201, 201, 201), 
                new Ray
                {
                    Origin = Vector3.Zero, 
                    Direction = Vector3.One
                },
                500
            },
        };
        
        [TestCaseSource(nameof(AABBNotHitCases))]
        public void AABBShouldNotBeHit(AABB aabb, Ray impactRay, float to)
        {
            bool hit = aabb.Test(ref impactRay, 0, to);

            hit.Should().BeFalse();
        }

        static object[] AABBNotHitCases =
        {
            new object[]
            {
                new AABB(-1, -1, -1, 1, 1, 1), 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = Vector3.UnitZ
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new AABB(-1, -1, -1, 1, 1, 1), 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = Vector3.UnitZ
                },
                0.5f
            },
            new object[]
            {
                new AABB(2, 2, 2, 4, 4, 4), 
                new Ray
                {
                    Origin = Vector3.Zero, 
                    Direction = Vector3.UnitY
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new AABB(200, 200, 200, 201, 201, 201), 
                new Ray
                {
                    Origin = Vector3.Zero, 
                    Direction = Vector3.One + Vector3.UnitX
                },
                float.PositiveInfinity
            },
        };
    }
}