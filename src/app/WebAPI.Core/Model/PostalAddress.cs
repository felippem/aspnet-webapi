using SharedKernel.Models;
using System;
using WebAPI.Core.Model.Agregates;
using WebAPI.Core.Model.Enums.Rules;

namespace WebAPI.Core.Model
{
    public class PostalAddress : EntityContract<PostalAddressRules, long>
    {
        public string Country { get; private set; }
        public string Complement { get; private set; }
        public DateTime Created { get; private set; }
        public string GeoCoordinates { get; private set; }
        public string Locality { get; private set; }
        public string Number { get; private set; }
        public string PostalCode { get; private set; }
        public string Region { get; private set; }
        public string StreetAddress { get; private set; }

        public virtual Establishment Establishment { get; private set; }
        public virtual Subsidiary Subsidiary { get; private set; }
        
        private PostalAddress()
        {
        }

        public PostalAddress(string country, string locality, string number,
            string postalCode, string region, string streetAddress)
        {
            if (string.IsNullOrWhiteSpace(country))
                this.Add(PostalAddressRules.Country, "O país é obrigatório");

            if (string.IsNullOrWhiteSpace(locality))
                this.Add(PostalAddressRules.Locality, "A localização é obrigatório");

            if (string.IsNullOrWhiteSpace(number))
                this.Add(PostalAddressRules.Number, "O número é obrigatório");

            if (string.IsNullOrWhiteSpace(postalCode))
                this.Add(PostalAddressRules.PostalCode, "O CEP é obrigatório");

            if (string.IsNullOrWhiteSpace(region))
                this.Add(PostalAddressRules.Region, "A região é obrigatório");

            if (string.IsNullOrWhiteSpace(streetAddress))
                this.Add(PostalAddressRules.StreetAddress, "O nome da rua é obrigatório");

            this.Country = country;
            this.Locality = locality;
            this.Number = number;
            this.PostalCode = postalCode;
            this.Region = region;
            this.StreetAddress = streetAddress;

            if (this.Id <= 0)
                this.Created = DateTime.Now;
        }
    }
}
