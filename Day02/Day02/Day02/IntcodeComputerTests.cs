using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Day02
{
    [TestFixture]
    public class IntcodeComputerTests
    {
        private IntcodeComputer _subject;

        [SetUp]
        public void InitTests()
        {
            _subject = new IntcodeComputer();
        }
        
        [Test]
        public void Compute_NeverHits99_IsNotFinished()
        {
            var input = new List<int> {0,0,0};
            _subject.Compute(input);
            _subject.IsFinished().Should().BeFalse("it should only finish on a 99");
        }
        
        [Test]
        public void Compute_Hits99_IsFinished()
        {
            var input = new List<int> {99};
            _subject.Compute(input);
            _subject.IsFinished().Should().BeTrue("because when it hits a 99 it should be finished");
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