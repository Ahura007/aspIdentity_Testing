using System.Collections.Generic;

namespace Dotin.Share.Dto.ApiResponse
{
    public class ResponseDto<T>
    {
        public List<string> Message {  get; set; }
        public string ApplicationMessage { get; set; }
        public List<T> Result { get; set; }
    }
}