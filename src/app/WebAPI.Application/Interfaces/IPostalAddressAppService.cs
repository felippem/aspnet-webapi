using System;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Interfaces
{
    public interface IPostalAddressAppService : IDisposable
    {
        PostalAddress Save(PostalAddress postalAddress);
    }
}
