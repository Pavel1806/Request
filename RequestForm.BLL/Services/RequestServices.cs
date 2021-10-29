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


            //var map = new MapperConfiguration(x => x.CreateMap<Request, RequestDTO>()).CreateMapper();
            //var rt = map.Map<IEnumerable<Request>, IEnumerable<RequestDTO>>(db.Requests.GetAll());
            List<Request> requests = db.Requests.GetAll();

            List<RequestDTO> request = new List<RequestDTO>();
            

            for(int i=0; i<requests.Count(); i++)
            {
                request.Add(new RequestDTO() {
                    Email = requests[i].Email,
                    DateTime = $"{requests[i].DateTime.Day}-{requests[i].DateTime.Month}-{requests[i].DateTime.Year}",
                    Name = requests[i].Name,
                    Number = requests[i].Number,
                    SerName = requests[i].SerName,
                    Position = requests[i].Position

            });

                
            }
            return request;
        }

        public RequestDTO GetRequestId(int? id)
        {

            var request = db.Requests.GetId(id.Value).FirstOrDefault();
            if (request == null)
                return null;

            return  new RequestDTO
            {
                DateTime = $"{request.DateTime.Day}-{request.DateTime.Month}-{request.DateTime.Year}",
                Email = request.Email,
                Name = request.Name,
                Number = request.Number,
                SerName = request.SerName,
                Position = request.Position
            };
        }

        public void CreateRequest(RequestDTO requestDTO)
        {

            //throw new Exception("Здесь очень много технической информации");

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

        public bool DeleteRequest(int number)
        {
            Request request = db.Requests.GetId(number).FirstOrDefault();
            if (request == null)
                return false;

            db.Requests.Delete(request);
            db.Save();
            return true;
        }





        public bool UpdateRequest(RequestDTO requestDTO)
        {
            var request = db.Requests.GetId(requestDTO.Number).FirstOrDefault();

            if (request == null)
                return false;

            request.Name = requestDTO.Name;
            request.SerName = requestDTO.SerName;
            request.Email = requestDTO.Email;
            request.Position = requestDTO.Position;

            db.Save();
            return true;
        }
    }
}
