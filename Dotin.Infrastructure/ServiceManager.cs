using System;
using Dotin.DataAccess.EfImpl.Ioc;
using Dotin.Domain.Impl.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotin.Infrastructure
{
    public static class ServiceManager
    {
        public static void ServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomainService(configuration);
            services.AddDataAccessRegister(configuration);
        }
    }
}
