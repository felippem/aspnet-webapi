using System.Collections.Generic;
using WebAPI.Application.ViewModels;

namespace WebAPI.Application.Interfaces
{
    public interface ISubsidiaryApplication
    {
        SubsidiaryViewModel Get(long id);
        IEnumerable<SubsidiaryViewModel> List();
        IEnumerable<SubsidiaryViewModel> List(long establishmentId);
        bool Remove(long id);
        SubsidiaryViewModel Save(SubsidiaryViewModel subsidiaryViewModel);
    }
}
