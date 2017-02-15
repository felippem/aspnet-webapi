using System;
using WebAPI.Core.Model;

namespace WebAPI.Core.Interfaces.Services
{
    public interface IPostalAddressService : IDisposable
    {
        PostalAddress Save(PostalAddress postalAddress);
    }
}
