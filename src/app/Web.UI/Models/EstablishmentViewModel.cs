using System;

namespace Web.UI.Models
{
    public class EstablishmentViewModel
    {
        #region Properties

        public bool AcceptsReservations { get; set; }
        public string AlternateName { get; set; }
        public string CurrenciesAccepted { get; set; }
        public string ContactName { get; set; }
        public DateTime Created { get; set; }
        public long EstablishmentKey { get; set; }
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public string LegalName { get; set; }
        public string Logo { get; set; }
        public string OpeningHours { get; set; }
        public string PriceRange { get; set; }
        public PostalAddressViewModel PostalAddress { get; set; }
        public string Telephone { get; set; }
        public string Tags { get; set; }

        #endregion
    }
}