using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public void ListIsNotNullAndHasItems()
        {
            int numberOfElements = 10;
            var list = Enumerable.Repeat(Mock.Of<object>(), numberOfElements).ToList();

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
        public void ListIsEmpty()
        {
            var list = It.IsAny<List<object>>();

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

        [Fact]
        public void CountAllElementsInIEnumerableOfType()
        {
            var enumerable = GetMixedObjectEnumerable();

            var countInt = enumerable.Count<object, int>();
            var countString = enumerable.Count<object, string>();
            var countDecimal = enumerable.Count<object, decimal>();
            var countBoolean = enumerable.Count<object, bool>();

            countInt.Should().Be(3);
            countString.Should().Be(2);
            countDecimal.Should().Be(0);
            countBoolean.Should().Be(1);
        }

        [Fact]
        public void CountAllElementsInIEnumerableOfTypeWithPredicate()
        {
            var enumerable = GetMixedObjectEnumerable();

            var countInt = enumerable.Count<object, int>();
            var countString = enumerable.Count<object, string>();
            var countDecimal = enumerable.Count<object, decimal>();
            var countBoolean = enumerable.Count<object, bool>();

            countInt.Should().Be(3);
            countString.Should().Be(2);
            countDecimal.Should().Be(0);
            countBoolean.Should().Be(1);
        }

        [Fact]
        public void IEnumerableHasType()
        {
            var enumerable = GetMixedObjectEnumerable();

            var hasType = enumerable.Has<object, string>();

            hasType.Should().BeTrue();
        }

        [Fact]
        public void IEnumerableHasNotType()
        {
            var enumerable = GetMixedObjectEnumerable();

            var hasType = enumerable.Has<object, decimal>();

            hasType.Should().BeFalse();
        }

        #region Data

        IEnumerable<object> GetMixedObjectEnumerable()
        {
            return new List<object>
            {
                0,
                1,
                2,
                "string",
                "value",
                true
            };
        }

        #endregion
    }
}