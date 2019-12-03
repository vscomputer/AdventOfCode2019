using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        
        [Test]
        public void Compute_MultiplyOperator2_ProductIsPlacedAtCorrectPositionAfterEndCode()
        {
            var input = new List<int> {2, 4, 4, 5, 99, 0};
            _subject.Compute(input);
            _subject.GetValueAtPosition(5).Should().Be(9801);
        }
        
        [Test]
        public void Compute_InterplayBetweenTwoOpcodes_CorrectValueAtBothPositions()
        {
            var input = new List<int> {1, 1, 1, 4, 99, 5, 6, 0, 99};
            _subject.Compute(input);
            _subject.GetValueAtPosition(0).Should().Be(30);
            _subject.GetValueAtPosition(4).Should().Be(2);
        }

        [Test]
        public void Compute_RealInputFilePartOne_CorrectAnswerAtPositionZero()
        {
            var input = File.ReadAllText("C:\\Projects\\Homework\\AdventOfCode2019-PuzzleInput\\day-2-input-part-1.txt")
                .Split(',').ToList();
            var castInput = new List<int>();
            foreach (var token in input)
            {
                castInput.Add(int.Parse(token));
            }
            _subject.Compute(castInput);
            Debug.WriteLine("0: " + _subject.GetValueAtPosition(0) + " noun: " + castInput[1] + " verb: " + castInput[2]);
            _subject.GetValueAtPosition(0).Should().Be(5434663);
        }

        [Test]
        public void PartTwo_IterateAcrossNounsAndVerbs_GetsNounAndVerb()
        {
            var input = File.ReadAllText("C:\\Projects\\Homework\\AdventOfCode2019-PuzzleInput\\day-2-input.txt")
                .Split(',').ToList();
            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    var castInput = new List<int>();
                    foreach (var token in input)
                    {
                        castInput.Add(int.Parse(token));
                    }

                    castInput[1] = noun;
                    castInput[2] = verb;
                    _subject.Compute(castInput);
                    _subject.GetValueAtPosition(0).Should().NotBe(19690720, "noun is " + noun + " and verb is " + verb);
                    Debug.WriteLine("0: " + _subject.GetValueAtPosition(0) + " noun: " + castInput[1] + " verb: " + castInput[2]);
                }
            }
            throw new Exception("shouldn't have gotten here, never hit the target value!");
        }
    }
}