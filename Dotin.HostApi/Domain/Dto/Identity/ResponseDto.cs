using System.Collections.Generic;

namespace Dotin.HostApi.Domain.Dto.Identity
{
    public class ResponseDto<T>
    {
        public List<string> IdentityMessage {  get; set; }
        public string ApplicationMessage { get; set; }
        public List<T> Result { get; set; }
    }
}