using Dotin.Domain.Model.Model.Application;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Impl.Mapper.Application
{
    public class GroupLedgerMapper : AutoMapper.Profile
    {
        public GroupLedgerMapper()
        {
            CreateMap<GroupLedger, GroupLedgerViewModel>();
            CreateMap<GroupLedgerViewModel, GroupLedger>();
        }
    }
}