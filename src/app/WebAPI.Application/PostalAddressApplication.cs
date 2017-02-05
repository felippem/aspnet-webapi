using System;
using WebAPI.Application.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Application
{
    public class PostalAddressApplication : IPostalAddressApplication
    {
        private IPostalAddressRepository _postalAddressRepository;
        
        public PostalAddressApplication(IPostalAddressRepository postalAddressRepository)
        {
            _postalAddressRepository = postalAddressRepository;
        }

        public PostalAddress Save(PostalAddress postalAddress)
        {
            if (postalAddress.PostalAddressId == 0)
            {
                postalAddress.Created = DateTime.Now;
                postalAddress = _postalAddressRepository.Create(postalAddress);
            }
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
