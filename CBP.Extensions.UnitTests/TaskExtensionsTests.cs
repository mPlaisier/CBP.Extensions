using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CBP.Extensions.UnitTests
{
    public class TaskExtensionsTests
    {
        [Fact]
        public void FireAndForgetAsyncSuccess()
        {
            SuccessTask().FireAndForgetSafeAsync(new ErrorClass());
        }

        [Fact]
        public void FireAndForgetFail()
        {
            Action act = () => FailingTask().FireAndForgetSafeAsync(new ErrorClass());

            act.Should().Throw<ArgumentException>();
        }

        #region Test methods

        Task FailingTask()
        {
            throw new ArgumentException();
        }

        Task SuccessTask()
        {
            return Task.FromResult(true);
        }

        #endregion

        #region ErrorTest class

        class ErrorClass : IErrorHandler
        {
            public void HandleError(Exception ex)
            {
                //Nothing required
            }
        }

        #endregion
    }
}