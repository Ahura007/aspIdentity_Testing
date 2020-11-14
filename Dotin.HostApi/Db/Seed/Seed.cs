using Dotin.HostApi.Db.Seed.SeedData;
using Dotin.HostApi.Domain.IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace Dotin.HostApi.Db.Seed
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var users = UserSeedData.CreateUser();
            var roles = RoleSeedData.CreateRole();

            modelBuilder.Entity<ApplicationUser>().HasData(users);
            modelBuilder.Entity<ApplicationRole>().HasData(roles);
        }
    }
}