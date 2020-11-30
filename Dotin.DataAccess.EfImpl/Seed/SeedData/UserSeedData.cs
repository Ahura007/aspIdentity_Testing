using System;
using System.Collections.Generic;
using Dotin.Domain.Model.Model.Identity;

namespace Dotin.DataAccess.EfImpl.Seed.SeedData
{
    public class UserSeedData
    {
        public static List<ApplicationUser> CreateUser()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-29),
                    NationalCode = "1234567891",
                    FirstName = "Admin",
                    LastName = "Admini",
                    PhoneNumber = "+989352810284",
                    UserName = "Admin",
                },
                new ApplicationUser
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