using System;
using Newtonsoft.Json;

namespace Dotin.HostApi.IdentityDto
{
    public class ApplicationUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

    }
}