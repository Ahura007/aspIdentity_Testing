using System.Collections.Generic;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.IdentityDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Domain.Service.Imp
{
    public class ResponseService<T> : IResponseService<T>
    {

        public ResponseDto<T> Build(T source, IEnumerable<IdentityError> errors, ActionResult actionResult, string message)
        {
            var res = new ResponseDto<T>();
            foreach (var error in errors)
            {
                res.IdentityError.Add(error.Description);
                res.IdentityCode.Add(error.Code);
            }

            res.Message = message;
            res.ActionResult = actionResult;
            res.Result = source;

            return res;
        }
    }
}