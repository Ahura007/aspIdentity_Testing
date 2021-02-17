using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Interface.Service.Interface.Application.LedgerDomain
{
    public interface ILedgerService
    {
        Task<ResponseDto<LedgerViewModel>> AddAsync(LedgerViewModel ledgerViewModel);
        Task<List<LedgerViewModel>> GetAllAsync();
        Task<LedgerViewModel> GetByIdAsync(params object[] keyValues);

    }
}
 