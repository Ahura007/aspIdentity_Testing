using System;
using Dotin.HostApi;
using Dotin.HostApi.Domain.Helper;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.Service.Interface;
using FluentAssertions;
using IdentityUnitTest.Helper;
using IdentityUnitTest.StartUp;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IdentityUnitTest.RealDb
{
    public class RealDbUserTest : IClassFixture<RealDatabaseStartup<Startup>>
    {

        public RealDatabaseStartup<Startup> Factory { get; set; }

        public RealDbUserTest(RealDatabaseStartup<Startup> factory)
        {
            Factory = factory;
        }



        [Fact]
        public async void Add_New_User()
        {
            using (var scope = Factory.Services.CreateScope())
            {
                var userName = RandomData.StringGenerator();

                var newUser = new ApplicationUserDto()
                {
                    FirstName = userName,
                    LastName = userName + "i",
                    NationalCode = RandomData.IntGenerate().ToString(),
                    PhoneNumber = RandomData.IntGenerate().ToString(),
                    BirthDate = DateTime.Now.AddYears(-30),
                    Email = userName + "@yahoo.com",
                    UserName = userName,
                    Password = "1",
                };

                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                var result = await userService.CreateAsync(newUser, newUser.Password);

                result.ApplicationMessage.Should().BeEquivalentTo(UserMessage.Success);

            }
        }



        [Fact]
        public async void Add_User_With_Duplicate_Username()
        {
            using (var scope = Factory.Services.CreateScope())
            {
                var newUser = new ApplicationUserDto()
                {
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-35),
                    NationalCode = "1234567891",
                    FirstName = "user",
                    LastName = "useri",
                    PhoneNumber = "+989352810284",
                    UserName = "user",
                    Password = "1"
                };
             
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                var result = await userService.CreateAsync(newUser, newUser.Password);

                result.ApplicationMessage.Should().BeEquivalentTo(UserMessage.Failed);
            }
        }




    }
}