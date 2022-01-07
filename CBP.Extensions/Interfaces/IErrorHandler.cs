using System;

namespace CBP.Extensions
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}