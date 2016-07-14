using System;

namespace WebAPI.Domain.Entities
{
    public class PostalAddress
    {
        #region Properties

        public long PostalAddressId { get; set; }
        public string Country { get; set; }
        public string Complement { get; set; }
        public DateTime Created { get; set; }
        public virtual Establishment Establishment { get; set; }
        public string GeoCoordinates { get; set; }
        public string Locality { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string StreetAddress { get; set; }

        #endregion
    }
}
