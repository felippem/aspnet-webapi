using WebAPI.Core.Model;
using WebAPI.Core.Model.Agregates;
using Xunit;

namespace WebAPI.Tests
{
    [Trait("Na criação de um estabelecimento", "")]
    public class CriarUmEstabelecimento
    {
        public CriarUmEstabelecimento()
        {
            
        }

        [Fact(DisplayName = "ao criar um estabelecimento com todas as informações")]
        public void EstabelecimentoValido()
        {
            Establishment establishment = new Establishment
                (alternateName: "Bar Figueiras",
                legalName: "Comércio de bebidas figueiras",
                email: "whatever@email.com",
                telephone: "11999999999");

            Assert.True(establishment.IsValid);
        }

        [Fact(DisplayName = "ao criar um estabelecimento inválido")]
        public void EstabelecimentoInvalido()
        {
            Establishment establishment = new Establishment
                (alternateName: "Bar Figueiras",
                legalName: "Comércio de bebidas figueiras",
                email: string.Empty,
                telephone: "11999999999");

            Assert.False(establishment.IsValid);
        }

        [Fact(DisplayName = "ao adicionar um endereço válido em um estabelecimento")]
        public void EstabelecimentoComEnderecoValido()
        {
            Establishment establishment = new Establishment
                (alternateName: "Bar Figueiras",
                legalName: "Comércio de bebidas figueiras",
                email: "whatever@email.com",
                telephone: "11999999999");

            PostalAddress postalAddress = new PostalAddress
                (country: "Brasil",
                locality: "São Paulo",
                number: "123",
                postalCode: "09371-076",
                region: "Santo André",
                streetAddress: "Rua das Figueiras");

            establishment.AddAddress(postalAddress);

            Assert.Equal(postalAddress, establishment.PostalAddress);
        }

        [Fact(DisplayName = "ao adicionar um endereço inválido em um estabelecimento")]
        public void EstabelecimentoComEnderecoInvalido()
        {
            Establishment establishment = new Establishment
                (alternateName: "Bar Figueiras",
                legalName: "Comércio de bebidas figueiras",
                email: "whatever@email.com",
                telephone: "11999999999");

            PostalAddress postalAddress = new PostalAddress
                (country: string.Empty,
                locality: "São Paulo",
                number: "123",
                postalCode: "09371-076",
                region: "Santo André",
                streetAddress: "Rua das Figueiras");

            establishment.AddAddress(postalAddress);

            Assert.False(postalAddress.IsValid);
            Assert.Null(establishment.PostalAddress);
        }

        [Fact(DisplayName = "quando o status de um estabelecimento sofrer alterações")]
        public void StatusDoEstabelecimentoAlternado()
        {
            Establishment establishment = new Establishment
                (alternateName: "Bar Figueiras",
                legalName: "Comércio de bebidas figueiras",
                email: "whatever@email.com",
                telephone: "11999999999");

            establishment.Status(false);
            
            Assert.False(establishment.Enabled);

            establishment.Status(true);

            Assert.True(establishment.Enabled);
        }
    }
}
