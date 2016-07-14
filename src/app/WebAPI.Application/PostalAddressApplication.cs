using System;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Application
{
    public class PostalAddressApplication
    {
        #region Fiedls

        private IPostalAddressRepository _postalAddressRepository;

        #endregion

        public PostalAddressApplication(IPostalAddressRepository postalAddressRepository)
        {
            _postalAddressRepository = postalAddressRepository;
        }

        #region Behaviors

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

        #endregion
    }
}
