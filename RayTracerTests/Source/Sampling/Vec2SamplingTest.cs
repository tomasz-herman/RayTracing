using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OpenTK;
using RayTracing.Sampling;

namespace RayTracerTests.Source.Sampling
{
    public class Vec2SamplingTest
    {
        [Test]
        public void DiskMappedSamplesShouldLayWithinDisk()
        {
            List<Vector2> rectangleSampled = new List<Vector2>
            {
                new Vector2(0, 0),
                new Vector2(0.25f, 0),
                new Vector2(0.5f, 0),
                new Vector2(0.75f, 0),
                new Vector2(1, 0),
                new Vector2(0, 0.25f),
                new Vector2(0.25f, 0.25f),
                new Vector2(0.5f, 0.25f),
                new Vector2(0.75f, 0.25f),
                new Vector2(1, 0.25f),
                new Vector2(0, 0.5f),
                new Vector2(0.25f, 0.5f),
                new Vector2(0.5f, 0.5f),
                new Vector2(0.75f, 0.5f),
                new Vector2(1, 0.5f),
                new Vector2(0, 0.75f),
                new Vector2(0.25f, 0.75f),
                new Vector2(0.5f, 0.75f),
                new Vector2(0.75f, 0.75f),
                new Vector2(1, 0.75f),
                new Vector2(0, 1),
                new Vector2(0.25f, 1),
                new Vector2(0.5f, 1),
                new Vector2(0.75f, 1),
                new Vector2(1, 1)
            };

            List<Vector2> diskSampled = rectangleSampled.ConvertAll(Vec2Sampling.ToDisk);

            diskSampled.Should()
                .NotContain(sample => sample.Length > 1, "that would mean that sample is not within a unit disk");
        }

        [Test]
        public void RegularGeneratingFunctionReturnsRequiredSizedSampleList()
        {
            const int samplesCount = 10;

            List<Vector2> samples = Vec2Sampling.Regular(samplesCount);

            samples.Should().HaveCount(samplesCount);
        }
        
        [Test]
        public void RegularSamplesLayOnGrid()
        {
            int samplesCount = 16;
            int gridSize = (int)Math.Sqrt(samplesCount);
            
            List<Vector2> samples = Vec2Sampling.Regular(samplesCount);
            List<float> xCoords = samples.GroupBy(sample => sample.X)
                .Select(group => group.First().X)
                .ToList();
            List<float> yCoords = samples.GroupBy(sample => sample.Y)
                .Select(group => group.First().Y)
                .ToList();

            samples.Should()
                .OnlyHaveUniqueItems()
                .And
                .HaveCount(samplesCount);

            xCoords.Should()
                .OnlyHaveUniqueItems()
                .And
                .HaveCount(gridSize);
            
            yCoords.Should()
                .OnlyHaveUniqueItems()
                .And
                .HaveCount(gridSize);
        }

        [Test]
        public void JitteredGeneratingFunctionReturnsRequiredSizedSampleList()
        {
            const int samplesCount = 10;

            List<Vector2> samples = Vec2Sampling.Jittered(samplesCount);

            samples.Should().HaveCount(samplesCount);
        }
        
        [Test]
        public void DummyGeneratingFunctionReturnsRequiredSizedSampleList()
        {
            const int samplesCount = 10;

            List<Vector2> samples = Vec2Sampling.Dummy(samplesCount);

            samples.Should().HaveCount(samplesCount);
        }
        
        [Test]
        public void RandomGeneratingFunctionReturnsRequiredSizedSampleList()
        {
            const int samplesCount = 10;

            List<Vector2> samples = Vec2Sampling.Random(samplesCount);

            samples.Should().HaveCount(samplesCount);
        }
    }
}