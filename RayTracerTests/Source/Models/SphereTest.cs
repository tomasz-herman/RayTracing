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
    public class SphereTest
    {
        [TestCaseSource(nameof(SphereNotHitCases))]
        public void SphereShouldNotBeHit(Sphere sphere, Ray impactRay, float to)
        {
            HitInfo info = new HitInfo();
            bool hit = sphere.HitTest(impactRay, ref info, 0, to);
            
            hit.Should().BeFalse();
        }
        
        [TestCaseSource(nameof(SphereHitCases))]
        public void SphereShouldBeHit(Sphere sphere, Ray impactRay, HitInfo expectedInfo)
        {
            HitInfo info = new HitInfo();
            bool hit = sphere.HitTest(impactRay, ref info, 0, float.PositiveInfinity);
            
            hit.Should().BeTrue();
            VectorsShouldBeApproximately(info.Normal, expectedInfo.Normal, Ray.Epsilon);
            VectorsShouldBeApproximately(info.HitPoint, expectedInfo.HitPoint, Ray.Epsilon);
            info.Distance.Should().BeApproximately(expectedInfo.Distance, Ray.Epsilon);
        }
        
        [Test]
        public void SphereHitMarksHitInfoWithItself()
        {
            Sphere sphere = new Sphere {Position = Vector3.Zero, Scale = 1};
            Ray ray = new Ray {Origin = 2 * Vector3.UnitZ, Direction = -Vector3.UnitZ};
            HitInfo info = new HitInfo();
            
            sphere.HitTest(ray, ref info, 0, float.PositiveInfinity);

            info.ModelHit.Should().Be(sphere);
        }
        
        static object[] SphereNotHitCases =
        {
            new object[]
            {
                new Sphere
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = Vector3.UnitZ
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new Sphere
                {
                    Position = Vector3.UnitY, 
                    Scale = 0.5f
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = -Vector3.UnitZ
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new Sphere
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = -Vector3.UnitY
                },
                float.PositiveInfinity
            },
            new object[]
            {
                new Sphere
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = -Vector3.UnitZ
                },
                0.5f
            },
        };
        
        static object[] SphereHitCases =
        {
            new object[]
            {
                new Sphere
                {
                    Position = Vector3.Zero, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = -Vector3.UnitZ
                }, 
                new HitInfo
                {
                    Distance = 1.0f,
                    HitPoint = Vector3.UnitZ,
                    Normal = Vector3.UnitZ
                }
            },
            new object[]
            {
                new Sphere
                {
                    Position = Vector3.UnitY, 
                    Scale = 1
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = -Vector3.UnitZ
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
                new Sphere
                {
                    Position = Vector3.Zero, 
                    Scale = 3
                }, 
                new Ray
                {
                    Origin = 2 * Vector3.UnitZ, 
                    Direction = -Vector3.UnitZ
                }, 
                new HitInfo
                {
                    Distance = 5.0f,
                    HitPoint = -3 * Vector3.UnitZ,
                    Normal = Vector3.UnitZ
                }
            },
        };
    }
    
    
}