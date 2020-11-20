using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [Test]
        public void RunsOpcodes_Day2Part2_FailsOnTheAnswer()
        {
            var parser = new ParsesOpcodeStrings();
            var subject = new RunsOpcodes(parser);
            var input = File.ReadAllText(@"C:\Projects\Homework\AdventOfCode2019-PuzzleInput\day-2-input-part-1.txt");
            var codes = parser.Parse(input);
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var codeArray = codes.ToArray();
                    codeArray[1] = noun;
                    codeArray[2] = verb;
                    
                    subject.Run(codeArray.ToList()).Should().NotStartWith("19690720");
                }
            }
            
        }
        
    }
}