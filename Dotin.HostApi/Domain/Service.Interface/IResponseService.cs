using System.Collections.Generic;
using Dotin.HostApi.Domain.IdentityDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IResponseService<T>
    {
        ResponseDto<T> Response(IList<T> source, string message);
        ResponseDto<T> Response(T source, string message);
        ResponseDto<T> Response(T source, IEnumerable<string> errors, string message);
    }
}