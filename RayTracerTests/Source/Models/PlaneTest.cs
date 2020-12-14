using System;
using FluentAssertions;
using NUnit.Framework;
using OpenTK;
using RayTracing;
using RayTracing.Maths;
using RayTracing.Models;
using static RayTracerTests.Source.TestUtils;

namespace RayTracerTests.Source.Models
{
    public class PlaneTest
    {
        [TestCaseSource(nameof(PlaneNotHitCases))]
        public void PlaneShouldNotBeHit(Plane plane, Ray impactRay, float to)
        {
            HitInfo info = new HitInfo();
            bool hit = plane.HitTest(impactRay, ref info, 0, to);
            
            hit.Should().BeFalse();
        }
        
        [TestCaseSource(nameof(PlaneHitCases))]
        public void PlaneShouldBeHit(Plane plane, Ray impactRay, HitInfo expectedInfo)
        {
            HitInfo info = new HitInfo();
            bool hit = plane.HitTest(impactRay, ref info, 0, float.PositiveInfinity);
            
            hit.Should().BeTrue();
            VectorsShouldBeApproximately(info.Normal, expectedInfo.Normal, Ray.Epsilon);
            VectorsShouldBeApproximately(info.HitPoint, expectedInfo.HitPoint, Ray.Epsilon);
            info.Distance.Should().BeApproximately(expectedInfo.Distance, Ray.Epsilon);
        }
        
        [Test]
        public void PlaneHitMarksHitInfoWithItself()
        {
            Plane plane = new Plane {Position = Vector3.Zero, Scale = 1};
            Ray ray = new Ray {Origin = 2 * Vector3.UnitY, Direction = -Vector3.UnitY};
            HitInfo info = new HitInfo();
            
            plane.HitTest(ray, ref info, 0, float.PositiveInfinity);

            info.ModelHit.Should().Be(plane);
        }
        
        static object[] PlaneNotHitCases =
        {
            new object[]
            {
                new Plane
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitY, 
                    Direction = Vector3.UnitY
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new Plane
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitY, 
                    Direction = -Vector3.UnitY
                },
                1.0f
            },
            new object[]
            {
                new Plane
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitY, 
                    Direction = Vector3.UnitZ
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new Plane
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitY, 
                    Direction = Vector3.UnitX
                },
                float.PositiveInfinity
            },
        };
        
        static object[] PlaneHitCases =
        {
            new object[]
            {
                new Plane
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitY, 
                    Direction = -Vector3.UnitY
                }, 
                new HitInfo
                {
                    Distance = 2.0f,
                    HitPoint = Vector3.Zero,
                    Normal = Vector3.UnitY
                }
            },
            new object[]
            {
                new Plane
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = -2 * Vector3.UnitY, 
                    Direction = Vector3.UnitY
                }, 
                new HitInfo
                {
                    Distance = 2.0f,
                    HitPoint = Vector3.Zero,
                    Normal = -Vector3.UnitY
                }
            },
            new object[]
            {
                new Plane
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = Vector3.One, 
                    Direction = -Vector3.Normalize(Vector3.One)
                }, 
                new HitInfo
                {
                    Distance = (float)Math.Sqrt(3),
                    HitPoint = Vector3.Zero,
                    Normal = Vector3.UnitY
                }
            },
            new object[]
            {
                new Plane
                {
                    Rotation = new Vector3((float)Math.PI / 2, 0, 0),
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.One, 
                    Direction = -Vector3.UnitZ
                }, 
                new HitInfo
                {
                    Distance = 2.0f,
                    HitPoint = new Vector3(2, 2, 0),
                    Normal = Vector3.UnitZ
                }
            },
        };
    }
}