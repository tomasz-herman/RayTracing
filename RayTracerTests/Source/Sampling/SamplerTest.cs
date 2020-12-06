using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RayTracing.Sampling;

namespace RayTracerTests.Source.Sampling
{
    public class SamplerTest
    {
        [Test]
        public void SamplerReturnsAllItsElements()
        {
            const int samplesCount = 100;
            List<int> Generator(int count) => Enumerable.Range(0, count).ToList();
            List<int> allSamples = Generator(samplesCount);
            Sampler<int> sampler = new Sampler<int>(Generator, samplesCount);

            List<int> returnedSamples = Enumerable.Range(0, samplesCount).Select(i => sampler.Sample).ToList();

            returnedSamples.Should().BeEquivalentTo(allSamples);
        }
    }
}