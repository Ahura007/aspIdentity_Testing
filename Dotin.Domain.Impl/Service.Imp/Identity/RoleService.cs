using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.Domain.Impl.Helper;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Domain.Model.Model.Identity;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dotin.Domain.Impl.Service.Imp.Identity
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IResponseService<ApplicationRoleCommand> _responseService;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<ApplicationRole> roleManager, IMapper mapper, IResponseService<ApplicationRoleCommand> responseService)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _responseService = responseService;
        }

        public async Task<ResponseDto<ApplicationRoleCommand>> CreateAsync(ApplicationRoleCommand roleCommand)
        {
            var isExistsRole = await IsExistsAsync(roleCommand);
            if (isExistsRole)
            {
                var newRole = _mapper.Map<ApplicationRoleCommand, ApplicationRole>(roleCommand);
                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                    return _responseService.Response(roleCommand, result.Errors.Select(c => c.Description), UserMessage.Success);
                return _responseService.Response(roleCommand, result.Errors.Select(c => c.Description), UserMessage.Failed);
            }
            return _responseService.Response(roleCommand, UserMessage.Duplicated);
        }

        public async Task<bool> IsExistsAsync(ApplicationRoleCommand roleCommand)
        {
            var isExistsRole = await _roleManager.FindByNameAsync(roleCommand.Name);
            if (isExistsRole == null)
                return true;
            return false;
        }

        public async Task<ResponseDto<ApplicationRoleCommand>> GetAllAsync()
        {
            var getAllRole = await _roleManager.Roles.ToListAsync();
            var allRole = _mapper.Map<List<ApplicationRole>, List<ApplicationRoleCommand>>(getAllRole);
            return _responseService.Response(allRole, UserMessage.Success);
        }

        public async Task<ResponseDto<ApplicationRoleCommand>> GetByIdAsync(int id)
        {
            var findRole = await _roleManager.Roles.FirstOrDefaultAsync(c => c.Id == id);
            var role = _mapper.Map<ApplicationRole, ApplicationRoleCommand>(findRole);
            return _responseService.Response(role, UserMessage.Success);
        }

        public async Task<List<ApplicationRoleCommand>> GetByNameAsync(List<string> names)
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