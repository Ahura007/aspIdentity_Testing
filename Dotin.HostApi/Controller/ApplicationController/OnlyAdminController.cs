using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.ApplicationController
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnlyAdminController : ControllerBase
    {
        [HttpPost]
        public string Test()
        {
            return null;
        }
    }
}