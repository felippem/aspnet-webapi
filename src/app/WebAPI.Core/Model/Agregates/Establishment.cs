using SharedKernel.Models;
using System;
using System.Collections.Generic;
using WebAPI.Core.Model.DomainEvents;
using WebAPI.Core.Model.Enums.Rules;

namespace WebAPI.Core.Model.Agregates
{
    public class Establishment : EntityContract<EstablihsmentRules, long>
    {
        public bool AcceptsReservations { get; private set; }
        public string AlternateName { get; private set; }
        public string CurrenciesAccepted { get; private set; }
        public string ContactName { get; private set; }
        public DateTime Created { get; private set; }
        public bool Deleted { get; private set; }
        public bool Enabled { get; private set; }
        public string Email { get; private set; }
        public string LegalName { get; private set; }
        public string Logo { get; private set; }
        public string OpeningHours { get; private set; }
        public string PriceRange { get; private set; }
        public string Telephone { get; private set; }
        public string Tags { get; private set; }

        public virtual PostalAddress PostalAddress { get; private set; }
        public virtual ICollection<Subsidiary> Subsidiaries { get; private set; }

        private Establishment()
        {
        }

        public Establishment(string alternateName, string legalName, string email, string telephone)
        {
            if (string.IsNullOrWhiteSpace(alternateName))
                this.Add(EstablihsmentRules.AlternateName, "O nome alternativo é obrigatório");

            if (string.IsNullOrWhiteSpace(legalName))
                this.Add(EstablihsmentRules.LegalName, "O nome legal é obrigatório");

            if (string.IsNullOrWhiteSpace(email))
                this.Add(EstablihsmentRules.Email, "O e-mail é obrigatório");

            if (string.IsNullOrWhiteSpace(telephone))
                this.Add(EstablihsmentRules.Telephone, "O telefone é obrigatório");

            this.AlternateName = alternateName;
            this.Email = email;
            this.LegalName = legalName;
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

        public void AddAddress(PostalAddress address)
        {
            if (address == null || !address.IsValid) return;
            
            this.PostalAddress = address;
        }

        public void Remove()
        {
            this.Deleted = true;
            this.Enabled = !this.Deleted;

            SharedKernel.DomainEventsDispatcher.DomainEvents.Raise(new EstablishmentRemovedEvent(this));
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
