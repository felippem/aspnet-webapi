using System;
using WebAPI.Core.Model;

namespace WebAPI.Application.Interfaces
{
    public interface IPostalAddressAppService : IDisposable
    {
        PostalAddress Save(PostalAddress postalAddress);
    }
}
