using System;

namespace Dotin.Domain.Model.Model.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public DateTime CreateDateTime { get; set; }
    }
}