using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Day01
{
    [TestFixture]
    public class DayOneTests
    {
        [Test]
        public void Calculate_MassIs12_FuelIs2()
        {
            var subject = new CalculatesFuelFromMass();
            subject.Calculate(12).Should().Be(2);
        }

        [Test]
        public void Calculate_MassIs14_FuelIs2()
        {
            var subject = new CalculatesFuelFromMass();
            subject.Calculate(14).Should().Be(2);
        }

        [Test]
        public void Calculate_MassIs1969_FuelIs654()
        {
            var subject = new CalculatesFuelFromMass();
            subject.Calculate(1969).Should().Be(966);
        }

        [Test]
        public void Calculate_MassIs100756_FuelIs33583()
        {
            var subject = new CalculatesFuelFromMass();
            subject.Calculate(100756).Should().Be(50346);
        }

        [Test]
        public void ParseFile_ThreeModules_FuelIs7()
        {
            var subject = new CalculatesFuelFromMass();
            subject.ParseFile("C:\\Projects\\Homework\\AdventOfCode2019\\Day01\\fakeInput.txt").Should().Be(7);
        }

        [Test]
        public void ParseFile_RealInput_FuelIsTheAnswer()
        {
            var subject = new CalculatesFuelFromMass();
            // subject.ParseFile("C:\\Projects\\Homework\\AdventOfCode2019\\Day01\\input.txt").Should().Be(3173518); //Part One answer
            subject.ParseFile("C:\\Projects\\Homework\\AdventOfCode2019\\Day01\\input.txt").Should().Be(4757427);
        }
    }

    public class CalculatesFuelFromMass
    {
        public decimal Calculate(decimal mass)
        {
            decimal result = 0;
            result += Math.Floor(mass / 3) - 2;
            if (Math.Floor(result / 3) - 2 > 0)
            {
                result += Calculate(result);
            }
            return result;
        }

        public decimal ParseFile(string fileName)
        {
            var modules = File.ReadAllLines(fileName);
            decimal result = 0;
            foreach (var module in modules)
            {                
                result += Calculate(int.Parse(module));
            }

            return result;
        }
    }
}