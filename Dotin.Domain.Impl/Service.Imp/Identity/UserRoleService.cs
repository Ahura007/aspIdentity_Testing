using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.Domain.Impl.Helper;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Domain.Model.Model.Identity;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;
using Microsoft.AspNetCore.Identity;

namespace Dotin.Domain.Impl.Service.Imp.Identity
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IResponseService<ApplicationUserCommand> _responseService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;


        public UserRoleService(UserManager<ApplicationUser> userManager, IResponseService<ApplicationUserCommand> responseService, IMapper mapper, IRoleService roleService)
        {
            _userManager = userManager;
            _responseService = responseService;
            _mapper = mapper;
            _roleService = roleService;
        }

        public async Task<ResponseDto<ApplicationUserCommand>> UserRoleAsync(AddUserRoleCommand userRoleCommand)
        {
            var currentUser = await _userManager.FindByIdAsync(userRoleCommand.UserId);
            var roleResult = await _userManager.AddToRolesAsync(currentUser, userRoleCommand.RoleNames);

            var userDto = _mapper.Map<ApplicationUser, ApplicationUserCommand>(currentUser);

            if (roleResult.Succeeded)
                return _responseService.Response(userDto, roleResult.Errors.Select(c => c.Description), UserMessage.Success);
            return _responseService.Response(userDto, roleResult.Errors.Select(c => c.Description), UserMessage.Failed);

        }
    }
}