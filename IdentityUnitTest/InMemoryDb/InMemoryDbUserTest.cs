using System;
using Dotin.HostApi;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.Service.Interface;
using IdentityUnitTest.StartUp;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IdentityUnitTest.InMemoryDb
{
    public class InMemoryDbUserTest : IClassFixture<InMemoryDatabaseStartup<Startup>>
    {

        public InMemoryDatabaseStartup<Startup> Factory { get; set; }

        public InMemoryDbUserTest(InMemoryDatabaseStartup<Startup> factory)
        {
            Factory = factory;
        }




        [Fact]
        public async void Add_New_User()
        {
            using (var scope = Factory.Services.CreateScope())
            {
                var newUser = new ApplicationUserDto()
                {
                    UserName = "user",
                    NationalCode = "1245788956",
                    BirthDate =DateTime.Now.AddYears(-30) ,
                    Password = "1",
                    LastName = "Lastnami",
                    PhoneNumber ="+981111111" ,
                    Email ="aaaa@yahoo.com" ,
                    FirstName = "user"
                };
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                var result = await userService.CreateAsync(newUser, newUser.Password);
            }
        }
    }
}