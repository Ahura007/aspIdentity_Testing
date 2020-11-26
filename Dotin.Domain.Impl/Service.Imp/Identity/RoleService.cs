using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.Domain.Impl.Helper;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Domain.Model.Model.Identity;
using Dotin.Share.Dto.Identity;
using Microsoft.AspNetCore.Identity;

namespace Dotin.Domain.Impl.Service.Imp.Identity
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IResponseService<ApplicationRoleDto> _responseService;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<ApplicationRole> roleManager, IMapper mapper, IResponseService<ApplicationRoleDto> responseService)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _responseService = responseService;
        }

        public async Task<ResponseDto<ApplicationRoleDto>> CreateAsync(ApplicationRoleDto roleDto)
        {
            var isExistsRole = await IsExistsAsync(roleDto);
            if (isExistsRole)
            {
                var newRole = _mapper.Map<ApplicationRoleDto, ApplicationRole>(roleDto);
                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                    return _responseService.Response(roleDto, result.Errors.Select(c => c.Description), UserMessage.Success);
                return _responseService.Response(roleDto, result.Errors.Select(c => c.Description), UserMessage.Failed);
            }
            return _responseService.Response(roleDto, UserMessage.Duplicated);
        }

        public async Task<bool> IsExistsAsync(ApplicationRoleDto roleDto)
        {
            var isExistsRole = await _roleManager.FindByNameAsync(roleDto.Name);
            if (isExistsRole == null)
                return true;
            return false;
        }

        public async Task<ResponseDto<ApplicationRoleDto>> GetAllAsync()
        {
            var getAllRole = await _roleManager.Roles.ToListAsync();
            var allRole = _mapper.Map<List<ApplicationRole>, List<ApplicationRoleDto>>(getAllRole);
            return _responseService.Response(allRole, UserMessage.Success);
        }

        public async Task<ResponseDto<ApplicationRoleDto>> GetByIdAsync(int id)
        {
            var findRole = await _roleManager.Roles.FirstOrDefaultAsync(c => c.Id == id);
            var role = _mapper.Map<ApplicationRole, ApplicationRoleDto>(findRole);
            return _responseService.Response(role, UserMessage.Success);
        }

        public async Task<List<ApplicationRoleDto>> GetByNameAsync(List<string> names)
        {
            var roles = new List<ApplicationRole>();
            foreach (var roleName in names)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                    roles.Add(role);
            }
            return null;
        }

    }
}