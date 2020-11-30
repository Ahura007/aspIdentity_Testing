using System.Collections.Generic;

namespace Dotin
{
    public class ResponseDto<T>
    {
        public List<string> Message {  get; set; }
        public string ApplicationMessage { get; set; }
        public List<T> Result { get; set; }
    }
}