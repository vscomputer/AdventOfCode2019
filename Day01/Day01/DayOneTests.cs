using System;
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
        
        
    }

    public class CalculatesFuelFromMass
    {
        public decimal  Calculate(decimal fuel)
        {
            return Math.Floor(fuel / 3) - 2;
        }
    }
}