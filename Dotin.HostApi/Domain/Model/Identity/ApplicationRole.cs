using System;
using Microsoft.AspNetCore.Identity;

namespace Dotin.HostApi.Domain.Model.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public DateTime CreateDateTime { get; set; }
    }
}