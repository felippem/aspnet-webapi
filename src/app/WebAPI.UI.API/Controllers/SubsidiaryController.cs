using System.Net;
using System.Web.Http;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModels;
using WebAPI.UI.API.Filters;
using WebAPI.UI.API.Models;

namespace WebAPI.UI.API.Controllers
{
    [ExceptitonFilter]
    public class SubsidiaryController : ApiController
    {
        #region Fields

        private ISubsidiaryAppService _subsidiaryApplication;

        #endregion

        public SubsidiaryController(ISubsidiaryAppService subsidiaryApplication)
        {
            _subsidiaryApplication = subsidiaryApplication;
        }

        #region Actions

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            if (id <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, id, "ID não é válido"));

            return Ok(FormatResult(1, _subsidiaryApplication.Get(id)));
        }

        [HttpGet]
        public IHttpActionResult List()
        {
            return Ok(FormatResult(1, _subsidiaryApplication.List()));
        }

        [HttpGet]
        public IHttpActionResult ListBy(long establishmentId)
        {
            if (establishmentId <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, establishmentId, "ID não é válido"));

            var subsidiaries = _subsidiaryApplication.List(establishmentId);

            return Ok(FormatResult(1, subsidiaries));
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]SubsidiaryViewModel entity)
        {
            var subsidiary = _subsidiaryApplication.Save(entity);

            return Ok(FormatResult(1, subsidiary));
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]SubsidiaryViewModel entity)
        {
            var subsidiary = _subsidiaryApplication.Save(entity);

            return Ok(FormatResult(1, subsidiary));
        }

        [HttpPatch]
        public IHttpActionResult AddEstablishment(long id, [FromBody]EstablishmentViewModel entity)
        {
            if (id <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, id, "ID não é válido"));

            var subsidiary = _subsidiaryApplication.AddEstablishment(id, entity);

            return Ok(FormatResult(1, subsidiary));
        }

        [HttpDelete]
        public IHttpActionResult Remove(long id)
        {
            if (id <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, id, "ID não é válido"));

            _subsidiaryApplication.Remove(id);

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
                _subsidiaryApplication.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
