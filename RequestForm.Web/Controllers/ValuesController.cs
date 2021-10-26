using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestForm.BLL.DTO;
using RequestForm.BLL.Interfaces;
using RequestForm.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestForm.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRequestServices _requestServices;

        public ValuesController(IRequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        /// <summary>
        /// Получить список заявок
        /// </summary>
        /// <remarks>
        /// GET /api/values
        /// </remarks>
        /// <returns>
        /// Список заявок с информацией о них.
        /// </returns>
        /// <response code="200">Запрос вполнился успешно, данные возвращены</response>
        /// <response code="204">Запрос вполнился успешно, данные не возвращены</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IEnumerable<RequestDTO> GetAll()
        {
            return _requestServices.GetAll();
        }

        /// <summary>
        /// Получить заявку по номеру
        /// </summary>
        /// <remarks>
        /// GET /api/values/
        /// </remarks>
        /// <returns>
        /// Одна заяка с информацией о ней.
        /// </returns>
        /// <response code="200">Запрос вполнился успешно, данные возвращены</response>
        /// <response code="204">Запрос вполнился успешно, данные не возвращены</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public RequestDTO GetRequestId(int id)
        {
            return _requestServices.GetRequestId(id);
        }

        [HttpPost]
        public void CreatRequest(RequestViewModel request)
        {
            var requestDTO = new RequestDTO
            {
                Name = request.Name,
                SerName = request.SerName,
                Email = request.Email,
                //Number = request.Number,
                Position = request.Position
            };
            _requestServices.CreateRequest(requestDTO);
        }

        [HttpDelete("{id}")]
        public void CreatRequest(int id)
        {
            _requestServices.DeleteRequest(id);
        }

        [HttpPut]
        public void UpdateRequest(RequestDTO requestDTO)
        {

            _requestServices.UpdateRequest(requestDTO);
        }

    }
}
