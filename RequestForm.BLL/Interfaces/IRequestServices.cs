using RequestForm.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.BLL.Interfaces
{
    public interface IRequestServices
    {
        IEnumerable<RequestDTO> GetAll();
        RequestDTO GetRequestId(int? id);
        void CreateRequest(RequestDTO request);
        bool DeleteRequest(int number);
        bool UpdateRequest(RequestDTO requestDTO);
    }
}
