using System;
using Dotin.HostApi.Domain.Helper;

namespace Dotin.Domain.Impl.Helper.ExceptionHandling
{
    public class DuplicateException : Exception
    {
        public DuplicateException()
        {
        }


        public DuplicateException(string error) : base(UserMessage.Duplicated)
        {
        }
    }
}