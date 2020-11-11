using System.Collections.Generic;
using Dotin.HostApi.Db.IdentityDbContext;
using Dotin.HostApi.Domain.Helper;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;
using Dotin.HostApi.Domain.Service.Imp;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotin.HostApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddService(Configuration);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            Test(Configuration);
        }


        void Test(IConfiguration configuration)
        {
             
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            //  app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}