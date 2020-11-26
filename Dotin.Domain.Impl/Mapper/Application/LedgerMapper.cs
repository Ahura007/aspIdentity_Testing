using System.Collections.Generic;
using Dotin.HostApi.Domain.Model.Application;

namespace Dotin.HostApi.Domain.Mapper.Application
{
    public class LedgerMapper : AutoMapper.Profile
    {
        public LedgerMapper()
        {
            CreateMap<Ledger, LedgerDto>();
            CreateMap<LedgerDto, Ledger>();
        }
    }
}