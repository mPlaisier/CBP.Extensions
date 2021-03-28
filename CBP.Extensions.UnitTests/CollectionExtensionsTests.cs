using System;
using System.Collections.ObjectModel;
using FluentAssertions;
using Moq;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void FindIndexReturnsCorrectValueIfNull()
        {
            Collection<object> list = null;

            var index = list.FindIndex(Mock.Of<Func<object, bool>>());

            index.Should().Be(-1, "collection is null");
        }

        [Fact]
        public void FindIndexReturnsCorrectValueIfEmpty()
        {
            Collection<object> list = new Collection<object>();

            var index = list.FindIndex(Mock.Of<Func<object, bool>>());

            index.Should().Be(-1, "collection is empty");
        }

        [Fact]
        public void FindIndexReturnsCorrectValue()
        {
            Collection<object> list = GetMixedObjectCollection();

            var indexBool = list.FindIndex(x => x is bool);
            var indexInt = list.FindIndex(x => x is int);
            var indexString = list.FindIndex(x => x is string);

            indexBool.Should().Be(5);
            indexInt.Should().Be(0);
            indexString.Should().Be(3);
        }



        #region Data

        Collection<object> GetMixedObjectCollection()
        {
            return new Collection<object>
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