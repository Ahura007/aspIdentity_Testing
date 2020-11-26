using System;
using Microsoft.AspNetCore.Identity;

namespace Dotin.Domain.Model.Model.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public DateTime CreateDateTime { get; set; }
    }
}