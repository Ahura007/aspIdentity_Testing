using System;
using System.Collections.Generic;
using Dotin.HostApi.Db.IdentityDbContext;
using Dotin.HostApi.Domain.IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotin.HostApi.Db.SeedData
{
    public static class Seed
    {
    
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(CreateUser());
            modelBuilder.Entity<ApplicationRole>().HasData(CreateRole());
        }  
        
        
        public static void SeedData(MigrationBuilder migrationBuilder)
        {

        }

        private static List<ApplicationUser> CreateUser()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = 1,
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-29),
                    NationalCode = "1234567891",
                    FirstName = "Admin",
                    LastName = "Admini",
                    PhoneNumber = "+989352810284",
                    UserName = "Admin"
                },
                new ApplicationUser
                {
                    Id = 2,
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-35),
                    NationalCode = "1234567891",
                    FirstName = "user",
                    LastName = "useri",
                    PhoneNumber = "+989352810284",
                    UserName = "user"
                }
            };
            return users;
        }

        private static List<ApplicationRole> CreateRole()
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Id = 1,
                    CreateDateTime = DateTime.Now,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole
                {
                    Id = 2,
                    CreateDateTime = DateTime.Now,
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            return roles;
        }
    }
}