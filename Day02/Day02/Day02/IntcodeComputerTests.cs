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
        public void Compute_InitialState_IsNotFinished()
        {
            var input = new List<int> {0,0,0};
            _subject.IsFinished().Should().BeFalse("it should only finish on a 99");
        }
        
        [Test]
        public void Compute_Hits99_IsFinished()
        {
            var input = new List<int> {99};
            _subject.Compute(input);
            _subject.IsFinished().Should().BeTrue("because when it hits a 99 it should be finished");
        }

        [Test]
        public void Compute_99IsAtLaterPosition_IsFinished()
        {
            var input = new List<int> {1, 0, 0, 0, 99};
            _subject.Compute(input);
            _subject.IsFinished().Should().BeTrue("it should move forward from a legit opcode");
        }

        [Test]
        [Ignore("this is next")]
        public void Compute_AddOperator1_SumIsPlacedAtCorrectPosition()
        {
            var input = new List<int> {1, 0, 0, 0, 99};
        }
    }

    public class IntcodeComputer
    {
        private const int OpcodeLength = 4;
        private bool _isFinished;

        public IntcodeComputer()
        {
            _isFinished = false;
        }
        
        public void Compute(List<int> input)
        {
            int i = 0;
            while (_isFinished == false)
            {
                if (input[i] == 99)
                    _isFinished = true;

                i += OpcodeLength;
            }
        }

        public bool IsFinished()
        {
            return _isFinished;
        }
    }
}