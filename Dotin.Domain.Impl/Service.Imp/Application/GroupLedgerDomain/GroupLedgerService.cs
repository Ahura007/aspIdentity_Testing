using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.DataAccess.Interface;
using Dotin.DataAccess.Interface.GroupLedgerDb;
using Dotin.DataAccess.Interface.LedgerDb;
using Dotin.Domain.Impl.Helper;
using Dotin.Domain.Impl.Helper.ExceptionHandling;
using Dotin.Domain.Interface.Service.Interface.Application.GroupLedgerDomain;
using Dotin.Domain.Interface.Service.Interface.Application.LedgerDomain;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Domain.Model.Model.Application;
using Dotin.HostApi.Domain.Helper.Extension;
using Dotin.Share.Dto.Application;

namespace Dotin.Domain.Impl.Service.Imp.Application.GroupLedgerDomain
{
    public class GroupLedgerService : IGroupLedgerService
    {
        private readonly IResponseService<GroupLedgerDto> _responseService;
        private readonly IGroupLedgerRepository _groupLedgerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GroupLedgerService(IMapper mapper, IResponseService<GroupLedgerDto> responseService, IUnitOfWork unitOfWork,
            IGroupLedgerRepository groupLedgerRepository)
        {

            _responseService = responseService;
            _unitOfWork = unitOfWork;
            _groupLedgerRepository = groupLedgerRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<GroupLedgerDto>> AddAsync(GroupLedgerDto groupLedgerDto)
        {
            var groupLedger = _mapper.Map<GroupLedgerDto, GroupLedger>(groupLedgerDto);


            try
            {
                await _groupLedgerRepository.AddAsync(groupLedger);

                await _unitOfWork.SaveChangesAsync();

                return _responseService.Response(groupLedgerDto, UserMessage.Success);
            }
            catch (Exception e)
            {
                var lastException = e.GetLastException();
                return _responseService.Response(groupLedgerDto, lastException.ReturnList(), UserMessage.Failed);
            }
        }

        public async Task<List<GroupLedgerDto>> GetAllAsync()
        {
            var allGroupLedger = await _groupLedgerRepository.GetAllAsync();
            var allLedgerDto = _mapper.Map<List<GroupLedger>, List<GroupLedgerDto>>(allGroupLedger);
            return allLedgerDto;
        }
    }
}