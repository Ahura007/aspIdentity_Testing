using System;
using System.Threading.Tasks;
using Dotin.DataAccess.EfImpl.Db.DbContext;
using Dotin.DataAccess.Interface;

namespace Dotin.DataAccess.EfImpl.Repository.Imp
{
    public class UnitOfWork : IUnitOfWork , IDisposable  
    {
        private bool disposed = false;
        private readonly ApplicationDbContext _applicationDbContext;


        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _applicationDbContext.SaveChanges();
        }



    }
}