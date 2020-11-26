using System.Collections.Generic;
using Dotin.HostApi.Domain.Model.Application.Base;

namespace Dotin.HostApi.Domain.Model.Application
{
    public class GroupLedger : Entity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual IList<GeneralLedger> GeneralLedgers { get; set; }
        public virtual Ledger Ledger { get; set; }
    }
}