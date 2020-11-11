using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.ApplicationController
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class OnlyUserController : ControllerBase
    {
        [HttpPost]
        public string Test()
        {
            return null;
        }
    }
}