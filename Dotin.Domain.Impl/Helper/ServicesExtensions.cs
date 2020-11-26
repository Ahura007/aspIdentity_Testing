using System;
using Dotin.Domain.Impl.Service.Imp.Identity;
using Dotin.HostApi.Domain.Mapper.Application;
using Dotin.HostApi.Domain.Mapper.Identity;
using Dotin.HostApi.Domain.Service.Imp.Application.LedgerDomain;
using Dotin.HostApi.Domain.Service.Imp.Identity;

namespace Dotin.Domain.Impl.Helper
{
    public static class ServicesExtensions
    {
        public static void AddService(this IServiceCollection services, IConfiguration configuration)
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

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILogoutService, LogoutService>();
            services.AddScoped(typeof(IResponseService<>), typeof(ResponseService<>));
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();

            //services.AddScoped<IUnitOfWork<ApplicationDbContext>, UnitOfWork<ApplicationDbContext>>();


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILedgerService, LedgerService>();
            services.AddScoped<ILegerRepository, LegerRepository>();
   



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