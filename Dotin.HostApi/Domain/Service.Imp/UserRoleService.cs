using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.HostApi.Domain.Helper;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Dotin.HostApi.Domain.Service.Imp
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IResponseService<ApplicationUserDto> _responseService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;


        public UserRoleService(UserManager<ApplicationUser> userManager, IResponseService<ApplicationUserDto> responseService, IMapper mapper, IRoleService roleService)
        {
            _userManager = userManager;
            _responseService = responseService;
            _mapper = mapper;
            _roleService = roleService;
        }

        public async Task<ResponseDto<ApplicationUserDto>> UserRoleAsync(AddUserRoleDto userRoleDto)
        {
            var currentUser = await _userManager.FindByIdAsync(userRoleDto.UserId);
            var roles = await _roleService.GetByNameAsync(userRoleDto.RoleNames);
            var allUserRole = await _userManager.GetRolesAsync(currentUser);
            IdentityResult roleResult = new IdentityResult();

            foreach (var role in roles)
            {
                if (!allUserRole.Contains(role.Name))
                {
                    roleResult = await _userManager.AddToRolesAsync(currentUser, userRoleDto.RoleNames);
                }
            }


            var userDto = _mapper.Map<ApplicationUser, ApplicationUserDto>(currentUser);

            if (roleResult.Succeeded)
                return _responseService.Response(userDto, roleResult.Errors.Select(c => c.Description), UserMessage.Success);
            return _responseService.Response(userDto, roleResult.Errors.Select(c => c.Description), UserMessage.Failed);

        }
    }
}