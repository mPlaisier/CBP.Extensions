using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void IEnumerableIsNotNullAndHasItems()
        {
            int numberOfElements = 10;
            var list = Enumerable.Repeat(Mock.Of<object>(), numberOfElements);

            var isNotEmpty = list.IsNotNullAndHasItems();
            var isEmpty = list.IsNullOrEmpty();

            isNotEmpty.Should().BeTrue();
            isEmpty.Should().BeFalse();
        }

        [Fact]
        public void IEnumerableIsEmpty()
        {
            var list = It.IsAny<IEnumerable<object>>();

            var isNotEmpty = list.IsNotNullAndHasItems();
            var isEmpty = list.IsNullOrEmpty();

            isEmpty.Should().BeTrue();
            isNotEmpty.Should().BeFalse();
        }

        [Fact]
        public void IEnumerableIsNull()
        {
            IEnumerable<object> list = null;

            var isNotEmpty = list.IsNotNullAndHasItems();
            var isEmpty = list.IsNullOrEmpty();

            isEmpty.Should().BeTrue();
            isNotEmpty.Should().BeFalse();
        }

        [Fact]
        public void IEnumerableForEachShouldThrowExceptionIfEmpty()
        {
            var list = It.IsAny<IEnumerable<object>>();

            Action act = () => list.ForEach(null);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}