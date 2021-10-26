using Microsoft.EntityFrameworkCore;
using RequestForm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}
    }
}
