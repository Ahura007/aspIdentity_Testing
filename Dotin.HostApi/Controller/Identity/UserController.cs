using System;
using System.Threading.Tasks;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.Identity
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
        public async Task<ResponseDto<ApplicationUserCommand>> OnPostAsync(ApplicationUserCommand user)
        {
            try
            {
                return await _userService.CreateAsync(user, user.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpGet]
        public async Task<ResponseDto<ApplicationUserCommand>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }
    }




}
