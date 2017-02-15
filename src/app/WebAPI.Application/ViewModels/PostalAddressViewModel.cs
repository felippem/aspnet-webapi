using System;
using System.Collections.Generic;

namespace WebAPI.Application.ViewModels
{
    public class PostalAddressViewModel
    {
        public long Key { get; set; }
        public string Country { get; set; }
        public string Complement { get; set; }
        public DateTime Created { get; set; }
        public string GeoCoordinates { get; set; }
        public string Locality { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string StreetAddress { get; set; }

        public HashSet<object> BrokenRules { get; set; }
    }
}