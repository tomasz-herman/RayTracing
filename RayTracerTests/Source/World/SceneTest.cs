using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OpenTK;
using RayTracing;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.RayTracing;
using RayTracing.World;

namespace RayTracerTests.Source.World
{
    public class SceneTest
    {
        [Test]
        public void HitTestShouldCallHitTestOnAllItsElements()
        {
            Mock<Sphere> modelA = new Mock<Sphere>();
            Mock<Plane> modelB = new Mock<Plane>();
            Scene scene = new Scene();
            scene.Hittables.Add(modelA.Object);
            scene.Hittables.Add(modelB.Object);
            HitInfo info = new HitInfo();
            
            scene.HitTest(new Ray(), ref info, 0, 0);
            
            modelA.Verify(m => m.HitTest(new Ray(), ref info, 0, 0));
            modelB.Verify(m => m.HitTest(new Ray(), ref info, 0, 0));
        }
    }
}