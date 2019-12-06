using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Day04
{
    public class GetsPasswordTests
    {
        private GetsPassword _subject;
        [SetUp]
        public void Setup()
        {
            _subject = new GetsPassword();
        }

        [TestCase("123456")]
        [TestCase("111111")]
        public void OnlyAscends_Ascending_ReturnsTrue(string input) => _subject.OnlyAscends(input).Should().BeTrue();

        [TestCase("123454")]
        [TestCase("111011")]
        public void OnlyAscends_Descends_ReturnsFalse(string input) => _subject.OnlyAscends(input).Should().BeFalse();

        [TestCase("123456")]
        public void ContainsAdjacentDigits_DoesNotContainAdjacentDigits_ReturnsFalse(string input)
        {
            _subject.ContainsAdjacentDigits(input);
        }
    }

    public class GetsPassword
    {
        public bool OnlyAscends(string input)
        {
            for (int i = input.Length -1; i > 0; i--)
            {
                if (int.Parse(input[i].ToString()) < int.Parse(input[i-1].ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ContainsAdjacentDigits(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}