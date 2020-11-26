using System;
using Microsoft.AspNetCore.Identity;

namespace Dotin.HostApi.Domain.Model.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}