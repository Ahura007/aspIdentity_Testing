using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.IdentityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.IdentityControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(ApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateAsync(model);
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet]
        public async Task<List<ApplicationUserDto>> GetAllAsync()
        {
            return await _userService.GetAll();
        }
    }




}
