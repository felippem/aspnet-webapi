using System;
using System.Collections.Generic;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Domain.Services
{
    public class SubsidiaryService : ISubsidiaryService
    {
        #region Fields

        private ISubsidiaryRepository _subsidiaryRepository;

        #endregion

        public SubsidiaryService(ISubsidiaryRepository subsidiaryRepository)
        {
            _subsidiaryRepository = subsidiaryRepository;
        }

        #region Behaviors

        public Subsidiary Save(Subsidiary subsidiary)
        {
            if (subsidiary.SubsidiaryId == 0)
            {
                subsidiary.Created = DateTime.Now;
                subsidiary = _subsidiaryRepository.Create(subsidiary);
            }
            else
                subsidiary = _subsidiaryRepository.Update(subsidiary);

            return subsidiary;
        }

        public Subsidiary Get(long id)
        {
            return _subsidiaryRepository.Get(id);
        }

        public IEnumerable<Subsidiary> List()
        {
            return _subsidiaryRepository.List();
        }

        public IEnumerable<Subsidiary> List(long establishmentId)
        {
            return _subsidiaryRepository.List(establishmentId);
        }

        public void Remove(long id)
        {
            var subsidiary = Get(id);

            if (subsidiary == null) return;

            subsidiary.Deleted = true;
            _subsidiaryRepository.Update(subsidiary);
        }

        public void Dispose()
        {
            _subsidiaryRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
