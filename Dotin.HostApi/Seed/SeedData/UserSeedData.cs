using System;
using System.Collections.Generic;
using Dotin.Share.Dto.Identity;

namespace Dotin.HostApi.Seed.SeedData
{
    public class UserSeedData
    {
        public static List<ApplicationUserDto> CreateUser()
        {
            var users = new List<ApplicationUserDto>
            {
                new ApplicationUserDto
                {
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-29),
                    NationalCode = "1234567891",
                    FirstName = "Admin",
                    LastName = "Admini",
                    PhoneNumber = "+989352810284",
                    UserName = "Admin",
                },
                new ApplicationUserDto
                {
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-35),
                    NationalCode = "1234567891",
                    FirstName = "user",
                    LastName = "useri",
                    PhoneNumber = "+989352810284",
                    UserName = "user",
                }
            };
            return users;
        }

 
    }
}