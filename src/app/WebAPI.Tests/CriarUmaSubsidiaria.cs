using WebAPI.Core.Model.Agregates;
using Xunit;

namespace WebAPI.Tests
{
    [Trait("Na criãção de uma subsidiária válida ou inválida", "")]
    public class CriarUmaSubsidiaria
    {
        public CriarUmaSubsidiaria()
        {

        }

        [Fact(DisplayName="ao criar uma subsidiária com todas as informações")]
        public void SubsidiariValida()
        {
            Subsidiary subsidiary = new Subsidiary
                (contactName: "Marie Clare",
                email: "marie@marie.com",
                telephone: "5511999999999",
                establishmentId: 1);

            Assert.True(subsidiary.IsValid);
        }

        [Fact(DisplayName="ao criar uma subsidiária inválida")]
        public void SubsidiariaInvalida()
        {
            Subsidiary subsidiary = new Subsidiary
                (contactName: "Marie Clare",
                email: "marie@marie.com",
                telephone: string.Empty,
                establishmentId: 1);

            Assert.False(subsidiary.IsValid);
        }

        [Fact(DisplayName = "ao vincular um estabelecimento válido em uma subsidiária")]
        public void VinculadoEstabelecimentoValido()
        {
            Subsidiary subsidiary = new Subsidiary
                (contactName: "Marie Clare",
                email: "marie@marie.com",
                telephone: "5511999999999",
                establishmentId: 1);

            Establishment establishment = new Establishment
                    (alternateName: "Bar Figueiras",
                    legalName: "Comércio de bebidas figueiras",
                    email: "whatever@email.com",
                    telephone: "11999999999");

            subsidiary.AddEstablishment(establishment);

            Assert.Equal(establishment, subsidiary.Establishment);
        }

        [Fact(DisplayName="ao vincular um estabelecimento inválido em uma subsidiária")]
        public void VincularEstabelecimentoInvalido()
        {
            Subsidiary subsidiary = new Subsidiary
                (contactName: "Marie Clare",
                email: "marie@marie.com",
                telephone: "5511999999999",
                establishmentId: 1);

            Establishment establishment = new Establishment
                    (alternateName: "Bar Figueiras",
                    legalName: "Comércio de bebidas figueiras",
                    email: string.Empty,
                    telephone: "11999999999");

            subsidiary.AddEstablishment(establishment);

            Assert.False(establishment.IsValid);
            Assert.Null(subsidiary.Establishment);
        }

        [Fact(DisplayName="quando o status de uma subsidiária sofrer alterações")]
        public void StatusDoEnderecoAlternado()
        {
            Subsidiary subsidiary = new Subsidiary
                (contactName: "Marie Clare",
                email: "marie@marie.com",
                telephone: "5511999999999",
                establishmentId: 1);

            subsidiary.Status(false);

            Assert.False(subsidiary.Enabled);

            subsidiary.Status(true);

            Assert.True(subsidiary.Enabled);
        }
    }
}
