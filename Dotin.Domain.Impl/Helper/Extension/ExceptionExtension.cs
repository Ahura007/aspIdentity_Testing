using System;

namespace Dotin.HostApi.Domain.Helper.Extension
{
    public static  class ExceptionExtension
    {
        public static string GetLastException(this Exception e)
        {
            while (e.InnerException != null) 
                e = e.InnerException;
            return e.ToString();
        }
    }
}