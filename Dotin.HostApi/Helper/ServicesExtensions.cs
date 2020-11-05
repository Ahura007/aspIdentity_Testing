using AutoMapper;
using Dotin.HostApi.Domain.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotin.HostApi.Helper
{
    public static class ServicesExtensions
    {
        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {

  

            services.AddSingleton(provider =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ApplicationRoleMapper>();
                    cfg.AddProfile<ApplicationUserMapper>();

                });
                return config.CreateMapper();
            });
        }
    }
}