﻿using System.Threading.Tasks;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.Identity
{

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ResponseDto<ApplicationRoleCommand>> GetAllAsync()
        {
            return await _roleService.GetAllAsync();
        }


        [HttpPost]
        public async Task<ResponseDto<ApplicationRoleCommand>> CreateAsync(ApplicationRoleCommand role)
        {
            return await _roleService.CreateAsync(role);
        }
    }
}

