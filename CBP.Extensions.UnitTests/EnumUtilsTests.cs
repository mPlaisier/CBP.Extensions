using System.Linq;
using FluentAssertions;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class EnumUtilsTests
    {
        enum ETest
        {
            Value1,
            Value2,
            Value3,

            Unknown
        }

        [Fact]
        public void EnumGeTValuesShouldReturnAllValues()
        {
            var enums = EnumUtil.GetValues<ETest>().ToList();

            enums.Should().HaveCount(4);

            enums[0].Should().Be(ETest.Value1);
            enums[1].Should().Be(ETest.Value2);
            enums[2].Should().Be(ETest.Value3);
            enums[3].Should().Be(ETest.Unknown);
        }

        [Fact]
        public void EnumGeTValuesShouldReturnAllValuesExceptUnknown()
        {
            var enums = EnumUtil.GetValuesExceptUnknown<ETest>().ToList();

            enums.Should().HaveCount(3);

            enums[0].Should().Be(ETest.Value1);
            enums[1].Should().Be(ETest.Value2);
            enums[2].Should().Be(ETest.Value3);
        }
    }
}
