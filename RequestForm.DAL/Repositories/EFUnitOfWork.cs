using Microsoft.EntityFrameworkCore;
using RequestForm.DAL.Context;
using RequestForm.DAL.Interfaces;
using RequestForm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {

        private IRepository<Request> requestRepository;
        private AppDbContext appDbContext;

        public EFUnitOfWork(DbContextOptions<AppDbContext> dbContextOptions)
        {
            appDbContext = new AppDbContext(dbContextOptions);
        }

        public IRepository<Request> Requests
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(appDbContext);
                return requestRepository;
            }
        }
        private bool disposed = false;
        public virtual void Dispose(bool desposing)
        {
            if(!this.disposed)
            {
                if(desposing)
                {
                    appDbContext.Dispose();
                }
                this.disposed = true;
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            appDbContext.SaveChanges();
        }
    }
}
