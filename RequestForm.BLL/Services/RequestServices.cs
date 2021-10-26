using AutoMapper;
using RequestForm.BLL.DTO;
using RequestForm.BLL.Interfaces;
using RequestForm.DAL.Interfaces;
using RequestForm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.BLL.Services
{
    public class RequestServices : IRequestServices
    {
        IUnitOfWork db;
        public RequestServices(IUnitOfWork efUnitOfWork)
        {
            db = efUnitOfWork;
        }
        public IEnumerable<RequestDTO> GetAll()
        {
            var map = new MapperConfiguration(x => x.CreateMap<Request, RequestDTO>()).CreateMapper();
            return map.Map<IEnumerable<Request>, IEnumerable<RequestDTO>>(db.Requests.GetAll());
        }

        public RequestDTO GetRequestId(int? id)
        {
            if (id == null)
                throw new ValidationException("Нет такого номера заявки", "");

            var request = db.Requests.GetId(id.Value).FirstOrDefault();
            if (request == null)
                throw new ValidationException("Такой заявки нет", "");

            return new RequestDTO
            {
                DateTime = request.DateTime,
                Email = request.Email,
                Name = request.Name,
                Number = request.Number,
                SerName = request.SerName,
                Position = request.Position
            };
        }

        public void CreateRequest(RequestDTO requestDTO)
        {
            Request req = db.Requests.LastRequestId();


            var request = new Request
            {
                Name = requestDTO.Name,
                SerName = requestDTO.SerName,
                Email = requestDTO.Email,
                Number = req.Number + 1,
                DateTime = DateTime.Now,
                Position = requestDTO.Position
            };



            db.Requests.Create(request);
            db.Save();
        }

        public void DeleteRequest(int number)
        {
            Request request = db.Requests.GetId(number).FirstOrDefault();

            db.Requests.Delete(request);
            db.Save();
        }

        public void UpdateRequest(RequestDTO requestDTO)
        {
            var request = db.Requests.GetId(requestDTO.Number).FirstOrDefault();

            request.Name = requestDTO.Name;
            request.SerName = requestDTO.SerName;
            request.Email = requestDTO.Email;
            request.Position = requestDTO.Position;

            db.Save();
        }
    }
}
