using System.Net;
using System.Web.Http;
using WebAPI.API.Filters;
using WebAPI.API.Models;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModels;

namespace WebAPI.API.Controllers
{
    [ExceptionFilter]
    public class EstablishmentController : ApiController
    {
        private IEstablishmentAppService _establishmentApplication;

        public EstablishmentController(IEstablishmentAppService establishmentApplication)
        {
            _establishmentApplication = establishmentApplication;
        }

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
    }
}
