using System;

namespace Web.UI.Models
{
    public class SubsidiaryViewModel
    {
        #region Properties

        public bool AcceptsReservations { get; set; }
        public string CurrenciesAccepted { get; set; }
        public string ContactName { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public EstablishmentViewModel Establishment { get; set; }
        public string OpeningHours { get; set; }
        public string PriceRange { get; set; }
        public PostalAddressViewModel PostalAddress { get; set; }
        public long SubsidiaryKey { get; set; }
        public string Telephone { get; set; }
        
        #endregion
    }
}