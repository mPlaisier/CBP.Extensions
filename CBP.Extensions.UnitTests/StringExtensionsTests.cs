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
    }
}
