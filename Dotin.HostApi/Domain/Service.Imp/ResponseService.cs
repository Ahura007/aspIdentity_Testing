using System.Collections.Generic;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Domain.Service.Imp
{
    public class ResponseService<T> : IResponseService<T>
    {
        private readonly ResponseDto<T> _result = new ResponseDto<T>();
        public ResponseService()
        {
            _result.IdentityMessage = new List<string>();
            _result.Result = new List<T>();
        }
        public ResponseDto<T> Response(IList<T> sourcesList, string message)
        {
            foreach (var source in sourcesList)
            {
                _result.Result.Add(source);
            }
            _result.ApplicationMessage = message;
            return _result;
        }

        public ResponseDto<T> Response(T sources, IEnumerable<string> errors, string message)
        {
            foreach (var error in errors)
            {
                _result.IdentityMessage.Add(error);
            }

            _result.Result.Add(sources); 
            _result.ApplicationMessage = message;
            return _result;
        }


        public ResponseDto<T> Response(T sources, string message)
        {
            _result.Result.Add(sources);
            _result.ApplicationMessage = message;
            return _result;
        }
    }
}