using RequestForm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        IEnumerable<T> GetId(int id);
        void Create(Request request);
        void Delete(Request request);
        void Update(Request request);
        Request LastRequestId();
    }
}
