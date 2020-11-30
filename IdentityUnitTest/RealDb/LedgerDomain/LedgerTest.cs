using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Dotin.DataAccess.Interface;
using Dotin.DataAccess.Interface.LedgerDb;
using Dotin.Domain.Impl.Helper;
using Dotin.Domain.Impl.Service.Imp.Application.LedgerDomain;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Domain.Model.Model.Application;
using Dotin.HostApi;
using Dotin.Share.Dto.Application;
using FluentAssertions;
using IdentityUnitTest.Helper;
using IdentityUnitTest.StartUp;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace IdentityUnitTest.RealDb.LedgerDomain
{
    public class LedgerTest : IClassFixture<RealDatabaseStartup<Startup>>
    {
        public LedgerTest(RealDatabaseStartup<Startup> factory)
        {
            Factory = factory;
        }

        public RealDatabaseStartup<Startup> Factory { get; set; }


        [Fact]
        public async void Add_New_Ledger()
        {
            using (var scope = Factory.Services.CreateScope())
            {
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                var responseService = scope.ServiceProvider.GetRequiredService<IResponseService<LedgerDto>>();
                var ledgerDto = new LedgerDto
                {
                    Code = RandomData.IntGenerate().ToString(),
                    Title = RandomData.StringGenerator(),
                    IsActive = true
                };
                var ledger = mapper.Map<LedgerDto, Ledger>(ledgerDto);
                var legerRepositoryMock = new Mock<ILegerRepository>();

                var unitOfWorkMock = new Mock<IUnitOfWork>();

                legerRepositoryMock.Setup(c => c.AddAsync(ledger)).Returns(Task.CompletedTask);
                unitOfWorkMock.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);


                var ledgerService = new LedgerService(legerRepositoryMock.Object, mapper,
                    responseService, unitOfWorkMock.Object);

                var result = await ledgerService.AddAsync(ledgerDto);

                result.ApplicationMessage.Should().BeEquivalentTo(UserMessage.Success);
            }
        }


        [Fact]
        public async void Add_Duplicate_Ledger_WithCode()
        {
            using (var scope = Factory.Services.CreateScope())
            {
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                var responseService = scope.ServiceProvider.GetRequiredService<IResponseService<LedgerDto>>();
                var ledgerDto = new LedgerDto
                {
                    Code = RandomData.IntGenerate().ToString(),
                    Title = RandomData.StringGenerator(),
                    IsActive = true
                };


                var legerRepositoryMock = new Mock<ILegerRepository>();
                var unitOfWorkMock = new Mock<IUnitOfWork>();

                legerRepositoryMock.Setup(c => c.ExistsAsync(It.IsAny<Expression<Func<Ledger, bool>>>()))
                    .ReturnsAsync((Expression<Func<Ledger, bool>> pre) => { return true; });


                unitOfWorkMock.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

                var ledgerService = new LedgerService(legerRepositoryMock.Object, mapper,
                    responseService, unitOfWorkMock.Object);

                var result = await ledgerService.AddAsync(ledgerDto);

                result.ApplicationMessage.Should().BeEquivalentTo(UserMessage.Duplicated);
            }
        }
    }
}