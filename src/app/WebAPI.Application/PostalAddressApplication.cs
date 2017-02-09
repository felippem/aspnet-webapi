using System;
using WebAPI.Application.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application
{
    public class PostalAddressApplication : IPostalAddressApplication
    {
        private IPostalAddressService _postalAddressService;

        public PostalAddressApplication(IPostalAddressService postalAddressService)
        {
            _postalAddressService = postalAddressService;
        }

        public PostalAddress Save(PostalAddress postalAddress)
        {
            postalAddress = _postalAddressService.Save(postalAddress);

            return postalAddress;
        }

        public void Dispose()
        {
            _postalAddressService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
