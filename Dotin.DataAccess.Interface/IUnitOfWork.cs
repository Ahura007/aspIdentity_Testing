using System;
using System.Threading.Tasks;

namespace Dotin.DataAccess.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}