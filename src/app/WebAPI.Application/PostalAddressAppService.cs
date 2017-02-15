using System;
using WebAPI.Application.Interfaces;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Model;

namespace WebAPI.Application
{
    public class PostalAddressAppService : IPostalAddressAppService
    {
        private IPostalAddressService _postalAddressService;

        public PostalAddressAppService(IPostalAddressService postalAddressService)
        {
            _postalAddressService = postalAddressService;
        }

        public PostalAddress Save(PostalAddress postalAddress)
        {
            if (postalAddress.IsValid)
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
