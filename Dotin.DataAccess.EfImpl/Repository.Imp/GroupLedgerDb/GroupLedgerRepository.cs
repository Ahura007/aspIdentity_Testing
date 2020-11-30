using Dotin.DataAccess.EfImpl.Db.DbContext;
using Dotin.DataAccess.Interface.GroupLedgerDb;
using Dotin.DataAccess.Interface.LedgerDb;
using Dotin.Domain.Model.Model.Application;

namespace Dotin.DataAccess.EfImpl.Repository.Imp.GroupLedgerDb
{
    public class GroupLedgerRepository : GenericRepository<GroupLedger>, IGroupLedgerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
     
        public GroupLedgerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}