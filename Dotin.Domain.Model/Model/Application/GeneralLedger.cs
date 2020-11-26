using System.Collections.Generic;
using Dotin.Domain.Model.Model.Application;
using Dotin.HostApi.Domain.Model.Application.Base;

namespace Dotin.HostApi.Domain.Model.Application
{
    public class GeneralLedger : Entity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual IList<SubLedger> SubLedgers { get; set; }
        public virtual GroupLedger GroupLedger { get; set; }
    }
}