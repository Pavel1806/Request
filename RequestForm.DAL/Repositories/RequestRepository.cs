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
    public class RequestRepository : IRepository<Request>
    {
        private readonly AppDbContext _appDbContext;

        public RequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Request> GetAll()
        {
            return _appDbContext.Requests.OrderBy(x => x.Id).ToList<Request>();
        }

        public IEnumerable<Request> GetById(int id)
        {
            return _appDbContext.Requests.Where(x => x.Number == id);
        }


        public void Create(Request request)
        {
            _appDbContext.Add(request);
        }

        public void Delete(Request request)
        {
            _appDbContext.Remove(request);
        }

        public void Update(Request request)
        {
            _appDbContext.Update(request);
        }

        public Request LastRequestId()
        {
            return _appDbContext.Requests.OrderBy(x=>x.Id).LastOrDefault();
        }
    }
}
