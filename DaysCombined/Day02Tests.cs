using System.Collections.Generic;
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
            subject.Run("1,0,0,0,99").Should().Be(2);
        }

        [Test]
        public void ParsesOpcodeStrings_TestString_ReturnsAListWithTheRightNumberOfValues()
        {
            var subject = new ParsesOpcodeStrings();
            List<decimal> result = subject.Parse("1,0,0,0,99");
            result.Count.Should().Be(5);
        }
    }

    public class ParsesOpcodeStrings
    {
        public List<decimal> Parse(string opcodeString)
        {
            var splitString = opcodeString.Split(',');
            return splitString.Select(decimal.Parse).ToList();
        }
    }

    public class RunsOpcodes
    {
        private readonly ParsesOpcodeStrings _parsesOpcodeStrings;
        public RunsOpcodes(ParsesOpcodeStrings parsesOpcodeStrings)
        {
            _parsesOpcodeStrings = new ParsesOpcodeStrings();
        }

        public decimal Run(string opcodeString)
        {
            var opcodes = _parsesOpcodeStrings.Parse(opcodeString);
            return opcodes[(int)opcodes[1]] + opcodes[(int)opcodes[2]];
        }
    }
}