using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Interface.Service.Interface.Application.GroupLedgerDomain
{
    public interface IGroupLedgerService
    {
        Task<ResponseDto<GroupLedgerDto>> AddAsync(GroupLedgerDto groupLedgerDto);
        Task<List<GroupLedgerDto>> GetAllAsync();

    }
}
 