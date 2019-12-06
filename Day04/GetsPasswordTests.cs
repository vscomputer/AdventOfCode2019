using FluentAssertions;
using NUnit.Framework;

namespace Day04
{
    public class GetsPasswordTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("123456")]
        [TestCase("111111")]
        public void OnlyAscends_Ascending_ReturnsTrue(string input)
        {
            var subject = new GetsPassword();
            subject.OnlyAscends(input).Should().BeTrue();
        }
    }

    public class GetsPassword
    {
        public bool OnlyAscends(string input)
        {
            return true;
        }
    }
}