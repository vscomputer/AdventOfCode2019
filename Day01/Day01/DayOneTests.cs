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
            subject.Calculate(1969).Should().Be(654);
        }

        [Test]
        public void Calculate_MassIs100756_FuelIs33583()
        {
            var subject = new CalculatesFuelFromMass();
            subject.Calculate(100756).Should().Be(33583);
        }

        [Test]
        public void ParseFile_ThreeModules_FuelIs7()
        {
            var subject = new CalculatesFuelFromMass();
            subject.ParseFile("C:\\Projects\\Homework\\AdventOfCode2019\\Day01\\fakeInput.txt").Should().Be(7);
        }

        
    }

    public class CalculatesFuelFromMass
    {
        public decimal Calculate(decimal mass)
        {
            return Math.Floor(mass / 3) - 2;
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