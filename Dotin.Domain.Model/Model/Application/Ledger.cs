using System.Collections.Generic;
using Dotin.Domain.Model.Model.Application.Base;

namespace Dotin.Domain.Model.Model.Application
{
    public class Ledger : Entity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public virtual IList<GroupLedger> GroupLedgers { get; set; }
    }
}