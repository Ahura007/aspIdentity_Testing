using System.Collections.Generic;


namespace Dotin.HostApi.Domain.Model.Application
{
    public class GroupLedgerDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
   
    }
}