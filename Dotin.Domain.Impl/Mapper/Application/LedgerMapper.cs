using Dotin.Domain.Model.Model.Application;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Impl.Mapper.Application
{
    public class LedgerMapper : AutoMapper.Profile
    {
        public LedgerMapper()
        {
            CreateMap<Ledger, LedgerViewModel>();
            CreateMap<LedgerViewModel, Ledger>();
        }
    }
}