using System.Net;
using System.Web.Http;
using Web.UI.Filters;
using Web.UI.Models;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModels;

namespace Web.UI.Controllers
{
    [ExceptitonFilter]
    public class EstablishmentController : ApiController
    {
        #region Fields

        private IEstablishmentApplication _establishmentApplication;

        #endregion

        public EstablishmentController(IEstablishmentApplication establishmentApplication)
        {
            _establishmentApplication = establishmentApplication;
        }

        #region Actions

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            if (id <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, id, "ID não é válido"));

            return Ok(FormatResult(1, _establishmentApplication.Get(id)));
        }

        [HttpGet]
        public IHttpActionResult List()
        {
            return Ok(FormatResult(1,  _establishmentApplication.List()));
        }

        [HttpGet]
        public IHttpActionResult ListBy([FromUri]string tag)
        {
            return Ok(FormatResult(1, _establishmentApplication.ListByTag(tag)));
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]EstablishmentViewModel entity)
        {
            var establishment = _establishmentApplication.Save(entity);

            return Ok(FormatResult(1, establishment));
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]EstablishmentViewModel entity)
        {
            var establishment = _establishmentApplication.Save(entity);

            return Ok(FormatResult(1, establishment));
        }

        [HttpDelete]
        public IHttpActionResult Remove(long id)
        {
            if (id <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, id, "ID não é válido"));

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
