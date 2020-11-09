using System.Collections.Generic;
using Dotin.HostApi.IdentityDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IResponseService<T>
    {
        ResponseDto<T> Build(T source, IEnumerable<IdentityError> errors, ActionResult actionResult, string message);
    }
}