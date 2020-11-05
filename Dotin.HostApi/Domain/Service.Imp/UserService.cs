using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dotin.HostApi.Domain.Service.Imp
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<bool> CreateAsync(ApplicationUserDto roleDto)
        {
            var user = _mapper.Map<ApplicationUserDto, ApplicationUser>(roleDto);
            var result = await _userManager.CreateAsync(user, roleDto.Password);
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<List<ApplicationUserDto>> GetAll()
        {
            var getAllUser = await _userManager.Users.ToListAsync();
            var allUser = _mapper.Map<List<ApplicationUser>, List<ApplicationUserDto>>(getAllUser);
            return allUser;
        }
    }
}