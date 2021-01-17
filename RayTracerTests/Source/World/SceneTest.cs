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
            modelA.Setup(x => x.Preprocess()).Returns(new List<IHittable>{modelA.Object});
            modelB.Setup(x => x.Preprocess()).Returns(new List<IHittable>{modelB.Object});
            Scene scene = new Scene {BvhMode = false};
            scene.Models.Add(modelA.Object);
            scene.Models.Add(modelB.Object);
            HitInfo info = new HitInfo();
            scene.Preprocess();
            scene.HitTest(new Ray(), ref info, 0, 0);
            
            modelA.Verify(m => m.HitTest(new Ray(), ref info, 0, 0));
            modelB.Verify(m => m.HitTest(new Ray(), ref info, 0, 0));
        }
    }
}