using Dotin.Domain.Model.Model.Application;
using Dotin.Domain.Model.Model.Identity;
using Dotin.HostApi.DataAccess.Db.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dotin.DataAccess.EfImpl.Db.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<GroupLedger> GroupLedgers { get; set; }
        public DbSet<GeneralLedger> GeneralLedgers { get; set; }
        public DbSet<SubLedger> SubLedgers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUser");
            modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRole");
            modelBuilder.SeedData();
        }
    }
}