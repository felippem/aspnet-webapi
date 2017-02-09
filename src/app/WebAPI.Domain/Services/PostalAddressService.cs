using System;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Domain.Services
{
    public class PostalAddressService : IPostalAddressService
    {
        #region Fields

        private IPostalAddressRepository _postalAddressRepository;

        #endregion

        #region Behaviors

        public PostalAddressService(IPostalAddressRepository postalAddressRepository)
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

        #endregion
    }
}