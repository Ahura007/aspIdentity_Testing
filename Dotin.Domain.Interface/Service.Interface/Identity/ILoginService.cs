using System.Threading.Tasks;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface ILoginService
    {
        Task<ResponseDto<LoginResultCommand>> LoginAsync(LoginCommand loginCommand);
    }
}

 