using System;
using System.Threading.Tasks;

namespace CBP.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Execute a Task and Forget.
        /// </summary>
        /// <param name="_"></param>
        public static void Forget(this Task _)
        {
            //Forget task and continue
        }

        /// <summary>
        /// Wraps <paramref name="task"/> in try-catch and handles errors via <paramref name="handler"/>.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="handler"></param>
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}