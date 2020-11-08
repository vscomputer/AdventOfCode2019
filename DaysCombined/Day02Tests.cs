using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
        
    }

    public class ParsesOpcodeStrings
    {
        public List<decimal> Parse(string opcodeString)
        {
            var splitString = opcodeString.Split(',');
            return splitString.Select(decimal.Parse).ToList();
        }

        public string Parse(List<decimal> opcodes)
        {
            var result = new StringBuilder();
            foreach (var opcode in opcodes)
            {
                result.Append(opcode.ToString(CultureInfo.InvariantCulture) + ",");
            }

            return result.Remove(result.Length - 1, 1).ToString(); //gotta remove that last comma
        }
    }

    public class RunsOpcodes
    {
        private readonly ParsesOpcodeStrings _parsesOpcodeStrings;
        public RunsOpcodes(ParsesOpcodeStrings parsesOpcodeStrings)
        {
            _parsesOpcodeStrings = new ParsesOpcodeStrings();
        }

        public string Run(string opcodeString)
        {
            var opcodes = _parsesOpcodeStrings.Parse(opcodeString);
            if (opcodes[0] == 1)
            {
                opcodes[(int) opcodes[3]] = opcodes[(int) opcodes[1]] + opcodes[(int) opcodes[2]];
            }
            else if (opcodes[0] == 2)
            {
                opcodes[(int) opcodes[3]] = opcodes[(int) opcodes[1]] * opcodes[(int) opcodes[2]];
            }

            return _parsesOpcodeStrings.Parse(opcodes);
        }
    }
}