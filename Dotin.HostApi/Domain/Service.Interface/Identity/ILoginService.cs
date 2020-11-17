using System.Threading.Tasks;
using Dotin.HostApi.Domain.Dto.Identity;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface ILoginService
    {
        Task<ResponseDto<LoginResultDto>> LoginAsync(LoginDto loginDto);
    }
}

 