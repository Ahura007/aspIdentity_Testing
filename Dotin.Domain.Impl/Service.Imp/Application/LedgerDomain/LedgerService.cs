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
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Impl.Service.Imp.Application.LedgerDomain
{
    public class LedgerService : ILedgerService
    {
        private readonly IResponseService<LedgerDto> _responseService;
        private readonly ILegerRepository _legerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public LedgerService(ILegerRepository legerRepository, IMapper mapper, IResponseService<LedgerDto> responseService, IUnitOfWork unitOfWork)
        {
            _legerRepository = legerRepository;
            _responseService = responseService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<LedgerDto>> AddAsync(LedgerDto ledgerDto)
        {

            var ledger = _mapper.Map<LedgerDto, Ledger>(ledgerDto);

            var duplicateCode = await _legerRepository.ExistsAsync(c => c.Code == ledger.Code);
            if (duplicateCode)
                return _responseService.Response(ledgerDto,  UserMessage.Duplicated);


            var duplicateTitle = await _legerRepository.ExistsAsync(c => c.Title == ledger.Title);
            if (duplicateTitle)
                throw new DuplicateException(UserMessage.Duplicated + " Title");


            try
            {
                await _legerRepository.AddAsync(ledger);

                await _unitOfWork.SaveChangesAsync();

                return _responseService.Response(ledgerDto, UserMessage.Success);
            }
            catch (Exception e)
            {
                var lastException = e.GetLastException();
                return _responseService.Response(ledgerDto, lastException.ReturnList(), UserMessage.Failed);
            }
        }

        public async Task<List<LedgerDto>> GetAllAsync()
        {
            var allLedger = await _legerRepository.GetAllAsync();
            var allLedgerDto = _mapper.Map<List<Ledger>, List<LedgerDto>>(allLedger);
            return allLedgerDto;
        }
    }
}