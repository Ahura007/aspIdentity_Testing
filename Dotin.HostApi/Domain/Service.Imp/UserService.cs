using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.Helper;
using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotin.HostApi.Domain.Service.Imp
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


        public async Task<ResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto roleDto)
        {
            var user = _mapper.Map<ApplicationUserDto, ApplicationUser>(roleDto);
            var result = await _userManager.CreateAsync(user, roleDto.Password);

            if (result.Succeeded)
                return _responseService.Build(roleDto, result.Errors, new OkResult(), UserMessage.Success);
            return _responseService.Build(roleDto, result.Errors, new BadRequestResult(), UserMessage.Failed);
        }

        public async Task<List<ApplicationUserDto>> GetAllAsync()
        {
            var getAllUser = await _userManager.Users.ToListAsync();
            var allUser = _mapper.Map<List<ApplicationUser>, List<ApplicationUserDto>>(getAllUser);
            return allUser;
        }
    }
}