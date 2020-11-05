using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dotin.HostApi.IdentityModel
{
    public class ApplicationRole : IdentityRole<int>
    {
        public DateTime CreateDateTime { get; set; }
    }
}