using FluentAssertions;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class BooleanExtensionsTests
    {
        [Theory]
        [InlineData(true, "Yes")]
        [InlineData(false, "No")]
        public void BoolToYesNoStringShouldReturnCorrectString(bool value, string expected)
        {
            var result = value.ToYesNoString();
            result.Should().Be(expected);
        }
    }
}
