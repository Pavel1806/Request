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

        //    appDbContext.Add(new Request
        //    {
        //        DateTime = DateTime.Now,
        //        Name = "Сергей",
        //        SerName = "Сергеев",
        //        Position = "электрик",
        //        Number = 12,
        //        Email = "1@mail.ru"
        //    });
        //    appDbContext.Add(new Request
        //    {
        //        DateTime = DateTime.Now,
        //        Name = "Иван",
        //        SerName = "Иванов",
        //        Position = "сантехник",
        //        Number = 13,
        //        Email = "2@mail.ru"
        //    });
        //    appDbContext.Add(new Request
        //    {
        //        DateTime = DateTime.Now,
        //        Name = "Илья",
        //        SerName = "Ильин",
        //        Position = "директор",
        //        Number = 14,
        //        Email = "3@mail.ru"
        //    });
        //    appDbContext.SaveChanges();
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

        public void Save()
        {
            appDbContext.SaveChanges();
        }
    }
}
