using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using RayTracing.Sampling;

namespace RayTracerTests.Source.Sampling
{
    public class TreadSafeSamplerTest
    {
        [Test]
        public void TreadSafeSamplerReturnsAllItsElements()
        {
            const int samplesCount = 100;
            List<int> Generator(int count) => Enumerable.Range(0, count).ToList();
            List<int> allSamples = Generator(samplesCount);
            Sampler<int> sampler = new Sampler<int>(Generator, samplesCount);

            List<int> returnedSamples = Enumerable.Range(0, samplesCount).Select(i => sampler.Sample).ToList();

            returnedSamples.Should().BeEquivalentTo(allSamples);
        }
        
        [Test]
        public void TreadSafeSamplerShouldBeThreadSafe()
        {
            const int samplesCount = 1;
            List<int> Generator(int count) => Enumerable.Range(0, count).ToList();
            ThreadSafeSampler<int> sampler = new ThreadSafeSampler<int>(Generator, samplesCount);
            
            Action action = () =>
            {
                Parallel.For(0, 1000, _ =>
                {
                    for (; _ < 1000; _++)
                    {
                        sampler.GetSample();
                    }
                });
            };
            
            action.Should().NotThrow();
        }
        
        [Test]
        public void TreadSafeSamplerReturnsAllItsElementsForEachThread()
        {
            const int samplesCount = 100;
            List<int> Generator(int count) => Enumerable.Range(0, count).ToList();
            ThreadSafeSampler<int> sampler = new ThreadSafeSampler<int>(Generator, samplesCount);
            List<int> allSamples = Generator(samplesCount);

            Parallel.For(0, 1000, _ =>
            {
                List<int> returnedSamples = Enumerable.Range(0, samplesCount).Select(i => sampler.Sample).ToList();

                returnedSamples.Should().BeEquivalentTo(allSamples);
            });
        }
    }
}