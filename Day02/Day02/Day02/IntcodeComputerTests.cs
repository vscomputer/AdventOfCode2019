using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Day02
{
    [TestFixture]
    public class IntcodeComputerTests
    {
        [Test]
        public void Compute_Hits99_IsFinished()
        {
            var subject = new IntcodeComputer();
            var input = new List<int> {99};
            subject.Compute(input);
            subject.IsFinished().Should().BeTrue("because when it hits a 99 it should be finished");
        }
    }

    public class IntcodeComputer
    {
        public void Compute(List<int> input)
        {
            throw new NotImplementedException();
        }

        public bool IsFinished()
        {
            throw new NotImplementedException();
        }
    }
}