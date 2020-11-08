using System.Diagnostics;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace DaysCombined
{
    [TestFixture]
    public class Day01Tests
    {
        
        // For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
        [Test]
        public void CalculatesFuelFromMass_CalculateFuel_12_ShouldBe2()
        {
            var subject = new CalculatesFuelFromMass();
            var result = subject.CalculateFuel(12);
            result.Should().Be(2);
        }
        
        //For a mass of 100756, the fuel required is 33583.
        [Ignore("This is invalid once you take fuel into account")]
        [Test]
        public void CalculatesFuelFromMass_CalculateFuel_100756_ShouldBe33583()
        {
            var subject = new CalculatesFuelFromMass();
            var result = subject.CalculateFuel(100756);
            result.Should().Be(33583);
        }

        [Test]
        public void CalculatesFuelFromMass_FuelTakenIntoAccount_1969_ShouldBe966()
        {
            var subject = new CalculatesFuelFromMass();
            var result = subject.CalculateFuel(1969);
            result.Should().Be(966);
        }

        [Test]
        public void CalculatesFuelFromMass_FuelTakenIntoAccount_fakeInput_ShouldBe968()
        {
            var subject = new CalculatesFuelFromMass();
            var lines = File.ReadAllLines(
                "C:\\Projects\\Homework\\AdventOfCode2019-PuzzleInput\\input-day-01-fake.txt");
            var finalResult = lines.Sum(line => subject.CalculateFuel(int.Parse(line)));

            finalResult.Should().Be(968);
        }

        [Test]
        public void CalculatesFuelFromMass_FuelTakenIntoAccount_realInput_ShouldBeTheAnswer()
        {
            var subject = new CalculatesFuelFromMass();
            var lines = File.ReadAllLines(
                "C:\\Projects\\Homework\\AdventOfCode2019-PuzzleInput\\input.txt");
            var finalResult = lines.Sum(line => subject.CalculateFuel(int.Parse(line)));

            finalResult.Should().Be(4757427);
        }
    }
}