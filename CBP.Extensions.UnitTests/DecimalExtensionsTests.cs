using FluentAssertions;
using Moq;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class DecimalExtensionsTests
    {
        [Theory]
        [InlineData(100)]
        [InlineData(1)]
        [InlineData(10000)]
        [InlineData(125.25)]
        [InlineData(126.4)]
        [InlineData(100.123)]
        [InlineData(123456789)]
        [InlineData(0)]
        public void DefaultFormatHas2Decimals(decimal amount)
        {
            var value = amount.DefaultFormat();
            var arrAmount = value.Split('.');

            arrAmount[1].Should().HaveLength(2);
        }

        [Fact]
        public void DefaultFormatShouldHaveEuroSymbol()
        {
            var amount = It.IsAny<decimal>();

            var formatted = amount.DefaultFormat();

            formatted.Should().Contain("€", Exactly.Once());
        }

        [Theory]
        [InlineData(100, 0)]
        [InlineData(1000, 1)]
        [InlineData(1000.25, 1)]
        [InlineData(123125.25, 1)]
        [InlineData(1231256.25, 2)]
        [InlineData(0.00, 0)]
        public void DefaultFormatShouldHaveThousandSeparator(decimal amount, int numberOfSeparators)
        {
            var formatted = amount.DefaultFormat();

            formatted.Should().Contain(",", Exactly.Times(numberOfSeparators));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(10000)]
        [InlineData(125.25)]
        [InlineData(-126.4)]
        public void DefaultNegativeFormatShouldAlwaysBeNegative(decimal amount)
        {
            var formatted = amount.DefaultNegativeFormat();

            formatted.Should().Contain("-", Exactly.Once());
        }

        [Theory]
        [InlineData(100)]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(10000)]
        [InlineData(-10000)]
        [InlineData(125.25)]
        [InlineData(-126.4)]
        public void DefaultFormatShouldAlwaysBeNegative(decimal amount)
        {
            var formatted = amount.DefaultFormat(true);

            formatted.Should().Contain("-", Exactly.Once());
        }

        [Theory]
        [InlineData(100)]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(10000)]
        [InlineData(-10000)]
        [InlineData(125.25)]
        [InlineData(-126.4)]
        public void DefaultFormatShouldAlwaysBePositive(decimal amount)
        {
            var formatted = amount.DefaultFormat(false);

            formatted.Should().NotContain("-");
        }

        [Theory]
        [InlineData(100, 9)]
        [InlineData(-100, 9)]
        [InlineData(0, 7)]
        [InlineData(10000, 12)]
        [InlineData(-10000, 12)]
        [InlineData(125.25, 9)]
        [InlineData(-126.4, 9)]
        [InlineData(8.5, 7)]
        [InlineData(4.57, 7)]
        public void DefaultFormatShouldHaveCorrectNumberOfCharactersForNegativeAmount(decimal amount, int characters)
        {
            var formatted = amount.DefaultFormat(true);

            formatted.Should().HaveLength(characters);
        }

        [Theory]
        [InlineData(100, 8)]
        [InlineData(-100, 8)]
        [InlineData(0, 6)]
        [InlineData(10000, 11)]
        [InlineData(-10000, 11)]
        [InlineData(125.25, 8)]
        [InlineData(-126.4, 8)]
        [InlineData(8.5, 6)]
        public void DefaultFormatShouldHaveCorrectNumberOfCharactersForPositiveAmount(decimal amount, int characters)
        {
            var formatted = amount.DefaultFormat(false);

            formatted.Should().HaveLength(characters);
        }
    }
}
