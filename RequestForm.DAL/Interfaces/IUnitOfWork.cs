using RequestForm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Request> Requests { get; }
        void Save();
    }
}
