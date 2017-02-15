using System;
using System.Collections.Generic;

namespace WebAPI.Application.ViewModels
{
    public class SubsidiaryViewModel
    {
        public bool AcceptsReservations { get; set; }
        public string CurrenciesAccepted { get; set; }
        public string ContactName { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public long EstablishmentKey { get; set; }
        public string OpeningHours { get; set; }
        public string PriceRange { get; set; }
        public PostalAddressViewModel PostalAddress { get; set; }
        public long Key { get; set; }
        public string Telephone { get; set; }

        public HashSet<object> BrokenRules { get; set; }
    }
}