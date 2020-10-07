using System;
using System.Threading.Tasks;

namespace Sifon.Code.Helpers
{
    internal class TaskHelper<T>
    {
        internal static Task<T> AsyncPattern(Func<T> func)
        {
            var tcs = new TaskCompletionSource<T>();
            try
            {
                tcs.SetResult(func());
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }

        internal static Task<T> AsyncPattern(Func<string, T> func, string param)
        {
            var tcs = new TaskCompletionSource<T>();
            try
            {
                tcs.SetResult(func(param));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }

        internal static Task<T> AsyncPattern(Func<string,string, T> func, string param1, string param2)
        {
            var tcs = new TaskCompletionSource<T>();
            try
            {
                tcs.SetResult(func(param1, param2));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }


        internal static Task<T> AsyncPattern(Func<BackupInfo.BackupInfo, T> func, BackupInfo.BackupInfo param)
        {
            var tcs = new TaskCompletionSource<T>();
            try
            {
                tcs.SetResult(func(param));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }
    }
}