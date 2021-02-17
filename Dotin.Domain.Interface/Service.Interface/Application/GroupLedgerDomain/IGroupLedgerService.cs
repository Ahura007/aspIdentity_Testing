using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Interface.Service.Interface.Application.GroupLedgerDomain
{
    public interface IGroupLedgerService
    {
        Task<ResponseDto<GroupLedgerViewModel>> AddAsync(GroupLedgerViewModel groupLedgerViewModel);
        Task<List<GroupLedgerViewModel>> GetAllAsync();

    }
}
 