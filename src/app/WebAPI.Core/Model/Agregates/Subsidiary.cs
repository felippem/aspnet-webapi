using SharedKernel.Models;
using System;
using WebAPI.Core.Model.Enums.Rules;

namespace WebAPI.Core.Model.Agregates
{
    public class Subsidiary : EntityContract<SubsidiaryRules, long>
    {
        public bool AcceptsReservations { get; private set; }
        public string CurrenciesAccepted { get; private set; }
        public string ContactName { get; private set; }
        public DateTime Created { get; private set; }
        public bool Deleted { get; private set; }
        public bool Enabled { get; private set; }
        public string Email { get; private set; }
        public string OpeningHours { get; private set; }
        public string PriceRange { get; private set; }
        public string Telephone { get; private set; }

        public virtual long EstablishmentId { get; private set; }
        public virtual Establishment Establishment { get; private set; }
        public virtual PostalAddress PostalAddress { get; private set; }

        private Subsidiary()
        {
        }

        public Subsidiary(string contactName, string email, string telephone, long establishmentId)
        {
            if (string.IsNullOrWhiteSpace(contactName))
                this.Add(SubsidiaryRules.ContactName, "O nome do contato é obrigatório");

            if (string.IsNullOrWhiteSpace(email))
                this.Add(SubsidiaryRules.Email, "O e-mail é obrigatório");

            if (string.IsNullOrWhiteSpace(telephone))
                this.Add(SubsidiaryRules.Telephone, "O telefone é obrigatório");

            if (establishmentId <= 0)
                this.Add(SubsidiaryRules.Establishment, "O id do estabelecimento é obrigatório");

            this.ContactName = contactName;
            this.Email = email;
            this.Telephone = telephone;

            if (this.Id == 0)
            {
                this.Created = DateTime.Now;
                this.Enabled = true;
            }
        }

        public bool Available()
        {
            return (this.Enabled && !this.Deleted);
        }

        public void AddEstablishment(Establishment establishment)
        {
            if (establishment == null || !establishment.IsValid) return;

            this.Establishment = establishment;
        }

        public void AddAddress(PostalAddress address)
        {
            if (address == null || !address.IsValid) return;
            
            this.PostalAddress = address;
        }

        public void Remove()
        {
            this.Deleted = true;
            this.Enabled = !this.Deleted;
        }

        public void Restore()
        {
            this.Deleted = false;
            this.Enabled = true;
        }

        public void Status(bool enabled)
        {
            this.Enabled = enabled;
        }
    }
}
