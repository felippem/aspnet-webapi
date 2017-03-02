using WebAPI.Core.Model;
using Xunit;

namespace WebAPI.Tests
{
    [Trait("Na criação de um endereço válido ou inválido", "")]
    public class CriarUmEndereco
    {
        public CriarUmEndereco()
        {

        }

        [Fact(DisplayName="ao criar um endereço com todas as informações")]
        public void EnderecoValido()
        {
            PostalAddress postalAddress = new PostalAddress
                (country: "Brasil",
                locality: "São Paulo",
                number: "123",
                postalCode: "09371-076",
                region: "Santo André",
                streetAddress: "Rua das Figueiras");

            Assert.True(postalAddress.IsValid);
        }

        [Fact(DisplayName="ao criar um endereço inválido")]
        public void EnderecoInvalido()
        {
            PostalAddress postalAddress = new PostalAddress
                (country: "Brasil",
                locality: "São Paulo",
                number: "123",
                postalCode: "09371-076",
                region: string.Empty,
                streetAddress: "Rua das Figueiras");

            Assert.False(postalAddress.IsValid);
        }
    }
}
