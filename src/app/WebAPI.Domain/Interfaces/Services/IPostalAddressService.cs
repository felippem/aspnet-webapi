using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces.Services
{
    public interface IPostalAddressService
    {
        PostalAddress Save(PostalAddress postalAddress);
    }
}
