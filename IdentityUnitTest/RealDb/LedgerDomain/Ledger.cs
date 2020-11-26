using Dotin.HostApi;
using Dotin.HostApi.Domain.Model.Application;
using Dotin.HostApi.Domain.Service.Interface.Application.LedgerDomain;
using IdentityUnitTest.StartUp;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IdentityUnitTest.RealDb.LedgerDomain
{
    public class Ledger : IClassFixture<RealDatabaseStartup<Startup>>
    {
        public RealDatabaseStartup<Startup> Factory { get; set; }

        public Ledger(RealDatabaseStartup<Startup> factory)
        {
            Factory = factory;
        }


        [Fact]
        public async void Add_New_Ledger()
        {
            using (var scope = Factory.Services.CreateScope())
            {
                var ledgerDto = new LedgerDto()
                {
                    Code = "1",
                    Title = "عنوان یک",
                    IsActive = true
                };


                var ledgerService = scope.ServiceProvider.GetRequiredService<ILedgerService>();

                var x = await ledgerService.AddAsync(ledgerDto);
            }
        }
    }
}