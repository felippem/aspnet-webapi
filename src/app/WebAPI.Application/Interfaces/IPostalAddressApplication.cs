using System;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Interfaces
{
    public interface IPostalAddressApplication : IDisposable
    {
        PostalAddress Save(PostalAddress postalAddress);
    }
}
