using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dotin.HostApi.Domain.Service.Imp
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }


        public async Task<ApplicationRoleDto> CreateAsync(ApplicationRoleDto roleDto)
        {
            var isExistsRole = await IsExists(roleDto);
            if (isExistsRole)
            {
                var newRole = _mapper.Map<ApplicationRoleDto, ApplicationRole>(roleDto);
                await _roleManager.CreateAsync(newRole);
            }
            return roleDto;
        }

        public async Task<bool> IsExists(ApplicationRoleDto roleDto)
        {
            var isExistsRole = await _roleManager.FindByNameAsync(roleDto.Name);
            if (isExistsRole == null)
                return true;
            return false;
        }

        public async Task<List<ApplicationRoleDto>> GetAll()
        {
            var getAllRole = await _roleManager.Roles.ToListAsync();
            var allRole = _mapper.Map<List<ApplicationRole>, List<ApplicationRoleDto>>(getAllRole);
            return allRole;
        }

        public async Task<ApplicationRoleDto> GetById(int id)
        {
            var findRole = await _roleManager.Roles.FirstOrDefaultAsync(c => c.Id == id);
            var newRole = _mapper.Map<ApplicationRole, ApplicationRoleDto>(findRole);
            return newRole;
        }
    }
}