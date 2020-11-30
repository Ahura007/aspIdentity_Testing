using Dotin.DataAccess.EfImpl.Db.DbContext;
using Dotin.DataAccess.Interface.LedgerDb;
using Dotin.Domain.Model.Model.Application;

namespace Dotin.DataAccess.EfImpl.Repository.Imp.LedgerDb
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