using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Domain.Interface.Service.Interface.Application.GroupLedgerDomain;
using Dotin.Share.Dto.Application;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.Application
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupLedgerController : ControllerBase
    {
        private readonly IGroupLedgerService _groupLedgerService;

        public GroupLedgerController(IGroupLedgerService groupLedgerService)
        {
            _groupLedgerService = groupLedgerService;
        }


        [HttpPost]
        public async Task<ResponseDto<GroupLedgerDto>> PostAsync(GroupLedgerDto groupLedgerDto)
        {
            return await _groupLedgerService.AddAsync(groupLedgerDto);
        }



        [HttpGet]
        public async Task<List<GroupLedgerDto>> GetAllAsync()
        {
            return await _groupLedgerService.GetAllAsync();
        }

    }
}