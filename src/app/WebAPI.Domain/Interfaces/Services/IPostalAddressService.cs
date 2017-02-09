using System;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces.Services
{
    public interface IPostalAddressService : IDisposable
    {
        PostalAddress Save(PostalAddress postalAddress);
    }
}
