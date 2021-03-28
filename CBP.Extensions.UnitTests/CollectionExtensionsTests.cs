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

        [Fact]
        public void FindIndexReturnsCorrectValueIfItemNotFound()
        {
            Collection<object> list = GetMixedObjectCollection();

            var indexDecimal = list.FindIndex(x => x is decimal);

            indexDecimal.Should().Be(-1);
        }

        [Fact]
        public void CollectionInsertRangeShouldThrowErrorIfNull()
        {
            Collection<object> listNull = null;
            var listEmpty = new Collection<object>();

            Action actWithCollectionNull = () => listNull.InsertRange(0,new Collection<object>());
            Action actWithEnumerableNull = () => listEmpty.InsertRange(0,null);
           
            actWithCollectionNull.Should().Throw<ArgumentNullException>();
            actWithEnumerableNull.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ObservableCollectionInsertRangeShouldThrowErrorIfNull()
        {
            ObservableCollection<object> listNull = null;
            var listEmpty = new ObservableCollection<object>();

            Action actWithCollectionNull = () => listNull.InsertRange(0, new ObservableCollection<object>());
            Action actWithenumerableNull = () => listEmpty.InsertRange(0, null);

            actWithCollectionNull.Should().Throw<ArgumentNullException>();
            actWithenumerableNull.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CollectioRemoveRangeShouldThrowErrorIfNull()
        {
            ObservableCollection<object> listNull = null;
            ObservableCollection<object> listEmpty = new ObservableCollection<object>();

            Action actWithCollectionNull = () => listNull.RemoveRange(new ObservableCollection<object>());
            Action actWithenumerableNull = () => listEmpty.RemoveRange(null);

            actWithCollectionNull.Should().Throw<ArgumentNullException>();
            actWithenumerableNull.Should().Throw<ArgumentNullException>();
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