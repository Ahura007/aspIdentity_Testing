using System.Threading.Tasks;
using Dotin.DataAccess.EfImpl.Db.IdentityDbContext;
using Dotin.DataAccess.Interface.Repository.Interface.LedgerDb;
using Dotin.HostApi.DataAccess.Repository.Interface;
using Dotin.HostApi.DataAccess.Repository.Interface.LedgerDb;
using Dotin.HostApi.Domain.Model.Application;
using Microsoft.EntityFrameworkCore;

namespace Dotin.HostApi.DataAccess.Repository.Imp.LedgerDb
{
    public class LegerRepository : GenericRepository<Ledger>, ILegerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
     
        public LegerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}