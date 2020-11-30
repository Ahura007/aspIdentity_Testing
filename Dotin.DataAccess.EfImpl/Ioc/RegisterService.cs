using System;
using Dotin.DataAccess.EfImpl.Db.DbContext;
using Dotin.DataAccess.EfImpl.Repository.Imp;
using Dotin.DataAccess.EfImpl.Repository.Imp.GroupLedgerDb;
using Dotin.DataAccess.EfImpl.Repository.Imp.LedgerDb;
using Dotin.DataAccess.Interface;
using Dotin.DataAccess.Interface.GroupLedgerDb;
using Dotin.DataAccess.Interface.LedgerDb;
using Dotin.Domain.Model.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotin.DataAccess.EfImpl.Ioc
{
    public static class RegisterService
    {

        public static void AddDataAccessRegister( this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings")));




            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();


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
            services.AddScoped<IGroupLedgerRepository, GroupLedgerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
      

    }
}