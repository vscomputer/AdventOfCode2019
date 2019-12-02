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
        public void Compute_NeverHits99_IsNotFinished()
        {
            var subject = new IntcodeComputer();
            var input = new List<int> {0,0,0};
            subject.Compute(input);
            subject.IsFinished().Should().BeFalse("it should only finish on a 99");
        }
        
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
        private bool _isFinished;

        public IntcodeComputer()
        {
            _isFinished = false;
        }
        
        public void Compute(List<int> input)
        {
            if (input[0] == 99)
                _isFinished = true;
        }

        public bool IsFinished()
        {
            return _isFinished;
        }
    }
}