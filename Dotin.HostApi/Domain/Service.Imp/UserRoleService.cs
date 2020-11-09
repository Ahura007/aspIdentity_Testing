using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.Helper;
using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;
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


        public UserRoleService(UserManager<ApplicationUser> userManager, IResponseService<ApplicationUserDto> responseService, IMapper mapper)
        {
            _userManager = userManager;
            _responseService = responseService;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ApplicationUserDto>> UserRoleAsync(AddUserRoleDto userRoleDto)
        {
            var currentUser = await _userManager.FindByIdAsync(userRoleDto.UserId);
            var roleResult = await _userManager.AddToRolesAsync(currentUser, userRoleDto.RoleIds);

            var userDto = _mapper.Map<ApplicationUser, ApplicationUserDto>(currentUser);

            if (roleResult.Succeeded)
                return _responseService.Build(userDto, roleResult.Errors, new OkResult(), UserMessage.Success);
            return _responseService.Build(userDto, roleResult.Errors, new BadRequestResult(), UserMessage.Failed);

        }
    }
}