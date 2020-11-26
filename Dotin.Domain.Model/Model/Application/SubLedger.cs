

using Dotin.HostApi.Domain.Model.Application;
using Dotin.HostApi.Domain.Model.Application.Base;

namespace Dotin.Domain.Model.Model.Application
{
    public class SubLedger : Entity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual GeneralLedger GeneralLedgers { get; set; }
    }
}