using System;
using WebAPI.Core.Interfaces.Repository;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Model;

namespace WebAPI.Core.Services
{
    public class PostalAddressService : IPostalAddressService
    {
        private IPostalAddressRepository _postalAddressRepository;

        public PostalAddressService(IPostalAddressRepository postalAddressRepository)
        {
            _postalAddressRepository = postalAddressRepository;
        }

        public PostalAddress Save(PostalAddress postalAddress)
        {
            if (postalAddress.Id == 0)
                postalAddress = _postalAddressRepository.Create(postalAddress);
            else
                postalAddress = _postalAddressRepository.Update(postalAddress);

            return postalAddress;
        }

        public void Dispose()
        {
            _postalAddressRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}