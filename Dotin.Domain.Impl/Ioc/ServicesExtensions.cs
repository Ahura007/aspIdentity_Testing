using AutoMapper;
using Domain.Impl.Service.Imp.Application.LedgerDomain;
using Dotin.Domain.Impl.Helper.TokenSetting;
using Dotin.Domain.Impl.Mapper.Identity;
using Dotin.Domain.Impl.Service.Imp.Identity;
using Dotin.Domain.Interface.Service.Interface.Application.LedgerDomain;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.HostApi.Domain.Mapper.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotin.Domain.Impl.Ioc
{
    public static class DomainServices
    {
        public static void AddDomainService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IResponseService<>), typeof(ResponseService<>));


            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILogoutService, LogoutService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();



 

            services.AddScoped<ILedgerService, LedgerService>();



            services.AddSingleton(provider =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ApplicationRoleMapper>();
                    cfg.AddProfile<ApplicationUserMapper>();
                    cfg.AddProfile<LedgerMapper>();
                });
                return config.CreateMapper();
            });
        }


    }
}