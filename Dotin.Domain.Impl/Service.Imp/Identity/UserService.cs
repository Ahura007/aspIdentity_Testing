using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Domain.Impl.Helper;
using Dotin.HostApi.Domain.Model.Identity;

namespace Dotin.Domain.Impl.Service.Imp.Identity
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IResponseService<ApplicationUserDto> _responseService;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, IResponseService<ApplicationUserDto> responseService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _responseService = responseService;
        }


        public async Task<ResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto userDto,string password)
        {
            var user = _mapper.Map<ApplicationUserDto, ApplicationUser>(userDto);
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
                return _responseService.Response(userDto, result.Errors.Select(c => c.Description), UserMessage.Success);
            return _responseService.Response(userDto, result.Errors.Select(c => c.Description), UserMessage.Failed);
        }


        public async Task<ResponseDto<ApplicationUserDto>> GetAllAsync()
        {
            var getAllUser = await _userManager.Users.ToListAsync();
            var allUser = _mapper.Map<List<ApplicationUser>, List<ApplicationUserDto>>(getAllUser);
            return _responseService.Response(allUser, UserMessage.Success);
        }
    }
}