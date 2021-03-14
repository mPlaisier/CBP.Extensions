using FluentAssertions;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class ClassExtensionsTests
    {
        [Theory]
        [InlineData("string", false)]
        [InlineData(5, false)]
        [InlineData(null, true)]
        public void CheckIfObjectIsNull(object obj, bool isNull)
        {
            var result = obj.IsNull();

            result.Should().Be(isNull);
        }

        [Theory]
        [InlineData("string", true)]
        [InlineData(5, true)]
        [InlineData(null, false)]
        public void CheckIfObjectIsNotNull(object obj, bool isNull)
        {
            var result = obj.IsNotNull();

            result.Should().Be(isNull);
        }
    }
}
