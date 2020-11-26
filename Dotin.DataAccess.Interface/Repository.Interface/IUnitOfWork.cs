using System;
using System.Threading.Tasks;


namespace Dotin.HostApi.DataAccess.Repository.Interface.LedgerDb
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}