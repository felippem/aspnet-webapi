using System.Collections.Generic;
using WebAPI.Application.ViewModels;

namespace WebAPI.Application.Interfaces
{
    public interface IEstablishmentApplication
    {
        EstablishmentViewModel Get(long id);
        IEnumerable<EstablishmentViewModel> List();
        IEnumerable<EstablishmentViewModel> ListByTag(string tag);
        bool Remove(long id);
        EstablishmentViewModel Save(EstablishmentViewModel establishmentViewModel);
    }
}
