using System;

namespace WebAPI.Domain.Entities
{
    public class Subsidiary
    {
        #region Properties

        public bool AcceptsReservations { get; set; }
        public string CurrenciesAccepted { get; set; }
        public string ContactName { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
        public string PriceRange { get; set; }
        public long SubsidiaryId { get; set; }
        public string Telephone { get; set; }
        
        public virtual Establishment Establishment { get; set; }
        public virtual PostalAddress PostalAddress { get; set; }

        #endregion

        #region Behaviors

        public bool Available()
        {
            return (this.Enabled && !this.Deleted);
        }

        #endregion
    }
}
