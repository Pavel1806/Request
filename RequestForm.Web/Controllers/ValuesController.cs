using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestForm.BLL.DTO;
using RequestForm.BLL.Interfaces;
using RequestForm.Web.ErrorHandling;
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
        /// <response code="200">Запрос выполнился успешно, данные возвращены</response>
        /// <response code="204">Запрос выполнился успешно, данные не возвращены</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IEnumerable<ModelEditRequest> GetAll()
        {
            var map = new MapperConfiguration(x => x.CreateMap<RequestDTO, ModelEditRequest>()).CreateMapper();
            return map.Map<IEnumerable<RequestDTO>, IEnumerable<ModelEditRequest>>(_requestServices.GetAll());

            //return _requestServices.GetAll();
        }

        /// <summary>
        /// Получить заявку по номеру
        /// </summary>
        /// <remarks>
        /// GET /api/values/{номер заявки}
        /// </remarks>
        /// <returns>
        /// Одна заяка с информацией о ней.
        /// </returns>
        /// <response code="200">Запрос выполнился успешно, данные возвращены</response>
        /// <response code="204">Запрос выполнился успешно, данные не возвращены</response>
        /// <response code="404">Данные не найдены</response>
        /// <response code="500">Ошибка на сервере</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ModelEditRequest GetRequestId(int id)
        {
            var request =  _requestServices.GetRequestId(id);

            if (request == null)
            {
                throw new HttpResponseException
                {
                    Status = StatusCodes.Status404NotFound,
                    Value = $"Заявки с номером {id} не существует"
                };
            }

            return new ModelEditRequest {
                DateTime = request.DateTime,
                Number = request.Number,
                Name = request.Name,
                SerName = request.SerName,
                Email = request.Email,
                Position = request.Position
            };
        }

        /// <summary>
        /// Создать заявку
        /// </summary>
        /// <remarks>
        /// POST /api/values/
        /// </remarks>
        /// <response code="200">Запрос выполнился успешно, запись создана</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void CreatRequest(RequestViewModel request)
        {

            var requestDTO = new RequestDTO
            {
                Name = request.Name,
                SerName = request.SerName,
                Email = request.Email,
                Position = request.Position
            };
            _requestServices.CreateRequest(requestDTO);
        }

        /// <summary>
        /// Удалить заявку
        /// </summary>
        /// <remarks>
        /// DELETE /api/values/{номер заявки}
        /// </remarks>
        /// <response code="200">Запрос выполнился успешно, запись удалена</response>
        /// <response code="404">Данные не найдены</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void DeleteRequest(int id)
        {
            var request = _requestServices.DeleteRequest(id);


            if (request == false)
            {
                throw new HttpResponseException
                {
                    Status = StatusCodes.Status404NotFound,
                    Value = $"Заявки с номером {id} не существует"
                };
            }
            
        }

        /// <summary>
        /// Корректировать заявку
        /// </summary>
        /// <remarks>
        /// PUT /api/values/
        /// </remarks>
        /// <response code="200">Запрос выполнился успешно, данные возвращены</response>
        /// <response code="204">Запрос выполнился успешно, данные не возвращены</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Данные не найдены</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void UpdateRequest(ModelEditRequest request)
        {

            var requestDTO = new RequestDTO
            {
                Number=request.Number,
                Name = request.Name,
                SerName = request.SerName,
                Email = request.Email,
                Position = request.Position
            };

            var req = _requestServices.UpdateRequest(requestDTO);

            if (req == false)
            {
                throw new HttpResponseException
                {
                    Status = StatusCodes.Status404NotFound,
                    Value = $"Заявки с номером {request.Number} не существует"
                };
            }

        }

    }
}
