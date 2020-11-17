using System.Collections.Generic;
using Dotin.HostApi.Domain.Dto.Identity;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface IResponseService<T>
    {
        ResponseDto<T> Response(IList<T> source, string message);
        ResponseDto<T> Response(T source, string message);
        ResponseDto<T> Response(T source, IEnumerable<string> errors, string message);
    }
}