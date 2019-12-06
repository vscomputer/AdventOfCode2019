using System.Collections.Generic;
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

        [TestCase("123456", false)]
        [TestCase("112345", true)]
        public void ContainsAdjacentDigits_DoesNotContainAdjacentDigits_ReturnsBool(string input, bool answer) =>
            _subject.ContainsAdjacentDigits(input).Should().Be(answer);

        [Test]
        public void CombineTests_ActualInput_NumberOfPossiblePasswords()
        {
            //254032-789860
            var PossiblePasswords = new List<int>();
            for (int i = 254032; i < 789860; i++)
            {
                if (_subject.OnlyAscends(i.ToString()) && _subject.ContainsAdjacentDigits(i.ToString()))
                {
                    PossiblePasswords.Add(i);
                }
            }

            PossiblePasswords.Count.Should().Be(1033);
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
            for (int i = input.Length -1; i > 0; i--)
            {
                if (int.Parse(input[i].ToString()) == int.Parse(input[i-1].ToString()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}