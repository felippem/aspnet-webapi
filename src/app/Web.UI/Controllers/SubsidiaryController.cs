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
    public class SubsidiaryController : ApiController
    {
        #region Fields

        private SubsidiaryApplication _subsidiaryApplication;

        #endregion

        public SubsidiaryController(SubsidiaryApplication subsidiaryApplication)
        {
            _subsidiaryApplication = subsidiaryApplication;
        }

        #region Actions

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            if (id <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, id, "ID não é válido"));

            return Ok(FormatResult(1, Mapper.Map<Subsidiary, SubsidiaryViewModel>(_subsidiaryApplication.Get(id))));
        }

        [HttpGet]
        public IHttpActionResult List()
        {
            return Ok(FormatResult(1, Mapper.Map<IEnumerable<Subsidiary>, IEnumerable<SubsidiaryViewModel>>
                (_subsidiaryApplication.List())));
        }

        [HttpGet]
        public IHttpActionResult ListBy(long establishmentId)
        {
            if (establishmentId <= 0)
                return Content(HttpStatusCode.BadRequest, FormatResult(2, establishmentId, "ID não é válido"));

            var subsidiaries = Mapper.Map<IEnumerable<Subsidiary>, IEnumerable<SubsidiaryViewModel>>
                (_subsidiaryApplication.List(establishmentId));

            return Ok(FormatResult(1, subsidiaries));
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]SubsidiaryViewModel entity)
        {
            var subsidiary = Mapper.Map<Subsidiary, SubsidiaryViewModel>(_subsidiaryApplication
                .Save(Mapper.Map<SubsidiaryViewModel, Subsidiary>(entity)));

            return Ok(FormatResult(1, subsidiary));
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]SubsidiaryViewModel entity)
        {
            var subsidiary = Mapper.Map<Subsidiary, SubsidiaryViewModel>(_subsidiaryApplication
                .Save(Mapper.Map<SubsidiaryViewModel, Subsidiary>(entity)));

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

        #endregion
    }
}
