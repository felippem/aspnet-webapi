using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Web.UI.Filters;
using Web.UI.Models;
using WebAPI.Application;
using WebAPI.Domain.Entities;

namespace Web.UI.Controllers
{
    [ExceptitonFilter]
    public class EstablishmentController : ApiController
    {
        #region Fields

        private EstablishmentApplication _establishmentApplication;

        #endregion

        public EstablishmentController(EstablishmentApplication establishmentApplication)
        {
            _establishmentApplication = establishmentApplication;
        }

        #region Actions

        [HttpGet]
        public IHttpActionResult Get(string key)
        { 
            long id = 0;

            // TO DO: Key será criptograda

            if (!long.TryParse(key, out id))
                return Content(HttpStatusCode.BadRequest, FormatResult(2, key, "Key não é válido"));

            var establishment = Mapper.Map<Establishment, EstablishmentViewModel>(_establishmentApplication.Get(id));

            return Ok(FormatResult(1, establishment));
        }

        [HttpGet]
        public IHttpActionResult List()
        {
            var establishments = Mapper.Map<IEnumerable<Establishment>, IEnumerable<EstablishmentViewModel>>(_establishmentApplication.List());

            return Ok(FormatResult(1, establishments));
        }

        [HttpGet]
        public IHttpActionResult ListByTag([FromUri]string tag)
        {
            var establishments = Mapper.Map<IEnumerable<Establishment>, IEnumerable<EstablishmentViewModel>>(_establishmentApplication.ListByTag(tag));

            return Ok(FormatResult(1, establishments));
        }

        [HttpPost]
        public IHttpActionResult Create(EstablishmentViewModel entity)
        {
            var establishment = Mapper.Map<Establishment, EstablishmentViewModel>(_establishmentApplication
                .Save(Mapper.Map<EstablishmentViewModel, Establishment>(entity)));

            return Ok(FormatResult(1, establishment));
        }

        [HttpPut]
        public IHttpActionResult Update(EstablishmentViewModel entity)
        {
            var establishment = Mapper.Map<Establishment, EstablishmentViewModel>(_establishmentApplication
                .Save(Mapper.Map<EstablishmentViewModel, Establishment>(entity)));

            return Ok(FormatResult(1, establishment));
        }

        [HttpDelete]
        public IHttpActionResult Remove(string key)
        {
            long id = 0;

            // TO DO: Key será criptograda

            if (!long.TryParse(key, out id))
                return Content(HttpStatusCode.BadRequest, FormatResult(2, key, "Key não é válido"));

            _establishmentApplication.Remove(id);

            return Ok(FormatResult(1, null));
        }

        #endregion

        #region Methods

        private ResultViewModel FormatResult(int code, object result, string message = null)
        {
            return new ResultViewModel()
            {
                Message = message,
                Result = result,
                Code = code
            };
        }

        #endregion
    }
}
