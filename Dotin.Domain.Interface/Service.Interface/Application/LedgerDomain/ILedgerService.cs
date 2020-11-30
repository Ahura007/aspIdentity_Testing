using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Interface.Service.Interface.Application.LedgerDomain
{
    public interface ILedgerService
    {
        Task<ResponseDto<LedgerDto>> AddAsync(LedgerDto ledgerDto);
        Task<List<LedgerDto>> GetAllAsync();

    }
}
 