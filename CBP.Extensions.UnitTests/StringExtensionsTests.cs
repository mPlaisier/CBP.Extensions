using System;
using FluentAssertions;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("abcd", 3)]
        [InlineData("abcd", 0)]
        [InlineData("abcdefghijklmno", 5)]
        public void TruncateShouldAddDotsAtTheEnd(string value, int max)
        {
            string result = value.Truncate(max);

            result.Should().EndWith("...");
        }

        [Theory]
        [InlineData("abcd", 4)]
        [InlineData("abcd", 5)]
        [InlineData("abcdefghijklmno", 100)]
        [InlineData("", 0)]
        public void TruncateShouldNotAddDotsAtTheEnd(string value, int max)
        {
            string result = value.Truncate(max);

            result.Should().NotEndWith("...");
        }

        [Fact]
        public void TruncateThrowErrorIfStringIsNull()
        {
            string value = null;

            Action act = () => value.Truncate(0);

            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("abcd", "Abcd")]
        [InlineData("Abcd", "Abcd")]
        [InlineData("abcd Abcd", "Abcd Abcd")]
        [InlineData("Abcd abcd", "Abcd abcd")]
        [InlineData("abcdefGhijklmno", "AbcdefGhijklmno")]
        public void FirstCharToUpperShouldCapitalizeFirstChar(string value, string expected)
        {
            string result = value.FirstCharToUpper();

            result.Should().Be(expected);
        }

        [Fact]
        public void FirstCharToUpperThrowErrorIfStringIsNull()
        {
            string value = null;

            Action act = () => value.FirstCharToUpper();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FirstCharToUpperThrowErrorIfStringIsEmpty()
        {
            string value = string.Empty;

            Action act = () => value.FirstCharToUpper();

            act.Should().Throw<ArgumentException>();
        }
    }
}
