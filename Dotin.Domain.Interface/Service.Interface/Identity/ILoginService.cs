using System.Threading.Tasks;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface ILoginService
    {
        Task<ResponseDto<LoginResultDto>> LoginAsync(LoginDto loginDto);
    }
}

 