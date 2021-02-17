using System;
using Dotin.Domain.Impl.Helper;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.HostApi;
using Dotin.Share.Dto.Identity;
using FluentAssertions;
using IdentityUnitTest.Helper;
using IdentityUnitTest.StartUp;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IdentityUnitTest.InMemoryDb.User
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
                var userName = RandomData.StringGenerator();
                var newUser = new ApplicationUserCommand()
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
                var userName = RandomData.StringGenerator();
                var firstUser = new ApplicationUserCommand()
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
                var secondUser = new ApplicationUserCommand()
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
                var firstResult = await userService.CreateAsync(firstUser, firstUser.Password);
                var secondResult = await userService.CreateAsync(secondUser, secondUser.Password);

                secondResult.ApplicationMessage.Should().BeEquivalentTo(UserMessage.Failed);
            }
        }
    }
}