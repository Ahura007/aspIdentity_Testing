using System.Threading.Tasks;
using Dotin.HostApi.IdentityDto;
using Microsoft.AspNetCore.Identity;


namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface ILoginService
    {
        Task<ResponseDto<LoginResultDto>> LoginAsync(LoginDto loginDto);
    }
}

 