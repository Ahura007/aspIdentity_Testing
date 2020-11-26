using System;
using Dotin.DataAccess.EfImpl.Db.IdentityDbContext;
using Dotin.DataAccess.Interface;
using Dotin.DataAccess.Interface.Repository.Interface.LedgerDb;
using Dotin.Domain.Model.Model.Identity;
using Dotin.HostApi.DataAccess.Repository.Imp;
using Dotin.HostApi.DataAccess.Repository.Imp.LedgerDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotin.DataAccess.EfImpl.Ioc
{
    public class RegisterService
    {

        public static void Register(  IServiceCollection services, IConfiguration configuration)
        {


  

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(500);
                options.Lockout.MaxFailedAccessAttempts = 1000000;
                options.Lockout.AllowedForNewUsers = false;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILegerRepository, LegerRepository>();
        }
      

    }
}