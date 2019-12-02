using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        public void Compute_AddOperator1_SumIsPlacedAtCorrectPosition()
        {
            var input = new List<int> {1, 0, 0, 0, 99};
            _subject.Compute(input);
            _subject.GetValueAtPosition(0).Should().Be(2);
        }

        [Test]
        public void Compute_AddOperator1AtSecondPosition_SumIsPlacedAtCorrectPosition()
        {
            var input = new List<int> {1, 0, 0, 0, 1, 4, 4, 4, 99};
            _subject.Compute(input);
            _subject.GetValueAtPosition(4).Should().Be(2);
        }
        
        [Test]
        public void Compute_MultiplyOperator2_ProductIsPlacedAtCorrectPosition()
        {
            var input = new List<int> {2, 3, 0, 3, 99};
            _subject.Compute(input);
            _subject.GetValueAtPosition(3).Should().Be(6);
        }
    }

    public class IntcodeComputer
    {
        private const int OpcodeLength = 4;
        private bool _isFinished;
        private List<int> _codes;

        public IntcodeComputer()
        {
            _isFinished = false;
        }
        
        public void Compute(List<int> input)
        {
            int operation;
            int m;
            int n;
            int resultPosition;
            
            _codes = input;
            int i = 0;
            while (_isFinished == false)
            {
                operation = _codes[i];
                if (operation == 99)
                {
                    _isFinished = true;
                    break;
                }
                    
                m = _codes[i + 1];
                n = _codes[i + 2];
                resultPosition = _codes[i + 3];
                switch (operation)
                {                    
                    case 1:
                        _codes[resultPosition] = _codes[m] + _codes[n];
                        break;
                    case 2:
                        _codes[resultPosition] = _codes[m] * _codes[n];
                        break;
                    default:
                        throw new ArgumentException();
                }                                                               
                i += OpcodeLength;
            }
        }

        public bool IsFinished()
        {
            return _isFinished;
        }

        public int GetValueAtPosition(int position)
        {
            return _codes[position];
        }
    }
}