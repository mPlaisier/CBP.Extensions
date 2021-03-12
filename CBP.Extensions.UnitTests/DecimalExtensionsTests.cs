﻿using FluentAssertions;
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
    }
}
