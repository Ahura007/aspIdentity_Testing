using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.HostApi.Domain.Helper;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Identity;
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
                return _responseService.Response(roleDto, result.Errors.Select(c => c.Description), UserMessage.Success);
            return _responseService.Response(roleDto, result.Errors.Select(c => c.Description), UserMessage.Failed);
        }

        public async Task<ResponseDto<ApplicationUserDto>> GetAllAsync()
        {
            var getAllUser = await _userManager.Users.ToListAsync();
            var allUser = _mapper.Map<List<ApplicationUser>, List<ApplicationUserDto>>(getAllUser);
            return  _responseService.Response(allUser, UserMessage.Success);
        }
    }
}