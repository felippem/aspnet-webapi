using System;
using System.Collections.Generic;
using WebAPI.Core.Interfaces.Repository;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Core.Services
{
    public class SubsidiaryService : ISubsidiaryService
    {
        private ISubsidiaryRepository _subsidiaryRepository;

        public SubsidiaryService(ISubsidiaryRepository subsidiaryRepository)
        {
            _subsidiaryRepository = subsidiaryRepository;
        }

        public Subsidiary Save(Subsidiary subsidiary)
        {
            if (subsidiary.Id <= 0)
                subsidiary = _subsidiaryRepository.Create(subsidiary);
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

            subsidiary.Remove();

            _subsidiaryRepository.Update(subsidiary);
        }

        public void Dispose()
        {
            _subsidiaryRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}