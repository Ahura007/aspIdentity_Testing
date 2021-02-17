using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.DataAccess.EfImpl.Db.DbContext;
using Dotin.Domain.Interface.Service.Interface.Application.LedgerDomain;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Dotin.HostApi.Controller.Application
{
    [ApiController]
    [Route("api/[controller]")]
    public class LedgerController : ControllerBase
    {
        private readonly ILedgerService _ledgerService;

        public LedgerController(ILedgerService ledgerService)
        {
            _ledgerService = ledgerService;
        }

        [HttpPost]
        public async Task<ResponseDto<LedgerViewModel>> PostAsync(LedgerViewModel ledgerViewModel)
        {
            return await _ledgerService.AddAsync(ledgerViewModel);
        }


        [HttpGet]
        public async Task<List<LedgerViewModel>> GetAllAsync()
        {
            return await _ledgerService.GetAllAsync();
        }



    }
}