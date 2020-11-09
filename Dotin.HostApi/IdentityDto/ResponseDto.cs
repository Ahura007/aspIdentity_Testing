using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.IdentityDto
{
    public class ResponseDto<T>
    {
        public List<string> IdentityError {  get; set; }
        public List<string> IdentityCode {  get; set; }
        public ActionResult ActionResult { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}