using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace DaysCombined
{
    [TestFixture]
    public class Day02Tests
    {
        //1,0,0,0,99 becomes 2,0,0,0,99 (1 + 1 = 2)
        [Test]
        public void RunsOpcodes_FirstTestInput_Returns2()
        {
            var subject = new RunsOpcodes(new ParsesOpcodeStrings());
            subject.Run("1,0,0,0,99").Should().Be("2,0,0,0,99");
        }

        [Test]
        public void ParsesOpcodeStrings_TestString_ReturnsAListWithTheRightNumberOfValues()
        {
            var subject = new ParsesOpcodeStrings();
            List<decimal> result = subject.Parse("1,0,0,0,99");
            result.Count.Should().Be(5);
        }

        [Test]
        public void ParsesOpcodeStrings_ListOfCodes_ParsedBackIntoText()
        {
            var subject = new ParsesOpcodeStrings();
            var input = new List<decimal> {0, 1, 2, 3};
            subject.Parse(input).Should().Be("0,1,2,3");
        }

        //2,3,0,3,99 becomes 2,3,0,6,99 (3 * 2 = 6).
        [Test]
        public void RunsOpcodes_Multiply_ReturnsExpectedString()
        {
            var subject = new RunsOpcodes(new ParsesOpcodeStrings());
            subject.Run("2,3,0,3,99").Should().Be("2,3,0,6,99");
        }

        //2,4,4,5,99,0 becomes 2,4,4,5,99,9801 (99 * 99 = 9801).
        [Test]
        public void RunsOpcodes_MultiplyTwo_ReturnsExpectedString()
        {
            var subject = new RunsOpcodes(new ParsesOpcodeStrings());
            subject.Run("2,4,4,5,99,0").Should().Be("2,4,4,5,99,9801");
        }
        
        //1,1,1,4,99,5,6,0,99 becomes 30,1,1,4,2,5,6,0,99.
        [Test]
        public void RunsOpcodes_MultipleOpcodes_ReturnsExpectedString()
        {
            var subject = new RunsOpcodes(new ParsesOpcodeStrings());
            subject.Run("1,1,1,4,99,5,6,0,99").Should().Be("30,1,1,4,2,5,6,0,99");
        }

        [Test]
        public void RunsOpcodes_Day2Part1_ReturnsTheAnswer()
        {
            var input = File.ReadAllText(@"C:\Projects\Homework\AdventOfCode2019-PuzzleInput\day-2-input-part-1.txt");
            var subject = new RunsOpcodes(new ParsesOpcodeStrings());
            subject.Run(input).Should().StartWith("5434663");
        }
        
    }
}