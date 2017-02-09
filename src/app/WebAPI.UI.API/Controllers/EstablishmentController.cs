using System.Net;
using System.Web.Http;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModels;
using WebAPI.UI.API.Filters;
using WebAPI.UI.API.Models;

namespace WebAPI.UI.API.Controllers
{
    [ExceptitonFilter]
    public class EstablishmentController : ApiController
    {
        #region Fields

        private IEstablishmentAppService _establishmentApplication;

        #endregion

        public EstablishmentController(IEstablishmentAppService establishmentApplication)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _establishmentApplication.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
