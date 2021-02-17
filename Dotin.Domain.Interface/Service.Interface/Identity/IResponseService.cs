using System;
using System.Collections.Generic;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IResponseService<T>
    {
        ResponseDto<T> Response(IList<T> source, string message);
        ResponseDto<T> Response(T source, string message);
        ResponseDto<T> Response(T source, IEnumerable<string> errors, string message);
    }
}