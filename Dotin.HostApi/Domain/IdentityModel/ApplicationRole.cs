using System;
using Microsoft.AspNetCore.Identity;

namespace Dotin.HostApi.Domain.IdentityModel
{
    public class ApplicationRole : IdentityRole<int>
    {
        public DateTime CreateDateTime { get; set; }
    }
}