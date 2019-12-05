using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Day03
{
    public class CircuitPanelTests
    {
        private CircuitPanel _subject;
        [SetUp]
        public void Setup()
        {
            _subject = new CircuitPanel();
        }

        [Test]
        public void MarkWire1_R8_Marks8PointsToTheRight()
        {
            _subject.MarkWire1("R8");
            for (int i = 1; i <= 8; i++)
            {
                _subject.GetWire1().Any(t => t.Item1 == i && t.Item2 == 0).Should().BeTrue();
            }            
        }

        [Test]
        public void MarkWire1_U5AfterR8_Marks5Points8ToTheRight()
        {
            _subject.MarkWire1("R8,U5");
            for (int i = -1; i >= -5; i--)
            {
                _subject.GetWire1().Any(t => t.Item1 == 8 && t.Item2 == i).Should().BeTrue();
            }
        }

        [Test]
        public void MarkWire1_CommaSeparatedAllDirections_CorrectPositionsMarked()
        {
            var input = "R8,U5,L5,D3";
            _subject.MarkWire1(input);
            for (int i = 1; i <= 8; i++)
            {
                _subject.GetWire1().Any(t => t.Item1 == i && t.Item2 == 0).Should().BeTrue();
            }
            for (int i = -1; i >= -5; i--)
            {
                _subject.GetWire1().Any(t => t.Item1 == 8 && t.Item2 == i).Should().BeTrue();
            }
            for (int i = 8; i >= 3; i--)
            {
                _subject.GetWire1().Any(t => t.Item1 == i && t.Item2 == -5).Should().BeTrue();
            }
            for (int i = -5; i <= -2; i++)
            {
                _subject.GetWire1().Any(t => t.Item1 == 3 && t.Item2 == i).Should().BeTrue();
            }
        }

        [Test]
        public void MarkWire2_CommaSeparatedList_2TotalIntersections()
        {
            var input1 = "R8,U5,L5,D3";
            _subject.MarkWire1(input1);
            var input2 = "U7,R6,D4,L4";
            _subject.MarkWire2(input2);
            _subject.GetIntersections().Count.Should().Be(2);
        }

        [Test]
        public void GetManhattanDistance_SimpleScenario_Returns6()
        {
            var input1 = "R8,U5,L5,D3";
            _subject.MarkWire1(input1);
            var input2 = "U7,R6,D4,L4";
            _subject.MarkWire2(input2);
            _subject.GetManhattanDistance().Should().Be(6);
        }

        [Test]
        public void GetManhattanDistance_Scenario2_Returns159()
        {
            var input1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            _subject.MarkWire1(input1);
            var input2 = "U62,R66,U55,R34,D71,R55,D58,R83";
            _subject.MarkWire2(input2);
            _subject.GetManhattanDistance().Should().Be(159);
        }

        [Test]
        public void GetManhattanDistance_Scenario3_Returns135()
        {
            var input1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";
            _subject.MarkWire1(input1);
            var input2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";
            _subject.MarkWire2(input2);
            _subject.GetManhattanDistance().Should().Be(135);
        }

        [Test]
        public void GetManhattanDistance_RealInput_ReturnsTheAnswerToPartOne()
        {
            var inputs = File.ReadLines("C:\\Projects\\Homework\\AdventOfCode2019-PuzzleInput\\day-3-input.txt")
                .ToList();

            _subject.MarkWire1(inputs[0]);
            _subject.MarkWire2(inputs[1]);
            _subject.GetManhattanDistance().Should().Be(489);
        }
        
    }
}