using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.DataAccess.Interface;
using Dotin.DataAccess.Interface.LedgerDb;
using Dotin.Domain.Impl.Helper;
using Dotin.Domain.Impl.Helper.ExceptionHandling;
using Dotin.Domain.Interface.Service.Interface.Application.LedgerDomain;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Domain.Model.Model.Application;
using Dotin.HostApi.Domain.Helper.Extension;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Impl.Service.Imp.Application.LedgerDomain
{
    public class LedgerService : ILedgerService
    {
        private readonly IResponseService<LedgerViewModel> _responseService;
        private readonly ILegerRepository _legerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public LedgerService(ILegerRepository legerRepository, IMapper mapper, IResponseService<LedgerViewModel> responseService, IUnitOfWork unitOfWork)
        {
            _legerRepository = legerRepository;
            _responseService = responseService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<LedgerViewModel>> AddAsync(LedgerViewModel ledgerViewModel)
        {

            var ledger = _mapper.Map<LedgerViewModel, Ledger>(ledgerViewModel);

            var duplicateCode = await _legerRepository.ExistsAsync(c => c.Code == ledger.Code);
            if (duplicateCode)
                return _responseService.Response(ledgerViewModel, UserMessage.Duplicated);


            var duplicateTitle = await _legerRepository.ExistsAsync(c => c.Title == ledger.Title);
            if (duplicateTitle)
                return _responseService.Response(ledgerViewModel, UserMessage.Duplicated);


            try
            {
                await _legerRepository.AddAsync(ledger);

                await _unitOfWork.SaveChangesAsync();

                return _responseService.Response(ledgerViewModel, UserMessage.Success);
            }
            catch (Exception e)
            {
                var lastException = e.GetLastException().ReturnList();
                return _responseService.Response(ledgerViewModel, lastException, UserMessage.Failed);
            }
        }

        public async Task<List<LedgerViewModel>> GetAllAsync()
        {
            var allLedger = await _legerRepository.GetAllAsync();
            var allLedgerDto = _mapper.Map<List<Ledger>, List<LedgerViewModel>>(allLedger);
            return allLedgerDto;
        }


        public  async Task<LedgerViewModel> GetByIdAsync(params object[] keyValues)
        {
            var ledger = await _legerRepository.GetByIdAsync(keyValues);
            var ledgerDto = _mapper.Map<Ledger, LedgerViewModel>(ledger);
            return ledgerDto;
        }
    }
}