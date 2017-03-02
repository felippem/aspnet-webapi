using WebAPI.Core.Model.Agregates;
using Xunit;

namespace WebAPI.Tests
{
    [Trait("Ao excluir e restaurar uma subsidiária", "")]
    public class ExcluirUmaSubsidiaria
    {
        public ExcluirUmaSubsidiaria()
        {

        }

        [Fact(DisplayName="ao excluir uma subsidiária")]
        public void ExcluindoUmaSubsidiaria()
        {
            Subsidiary subsidiary = new Subsidiary
                (contactName: "Marie Clare",
                email: "marie@marie.com",
                telephone: "5511999999999",
                establishmentId: 1);

            subsidiary.Remove();

            Assert.False(subsidiary.Available());
        }

        [Fact(DisplayName="ao restaurar uma subsidiária")]
        public void RestaurandoUmaSubsidiaria()
        {
            Subsidiary subsidiary = new Subsidiary
                (contactName: "Marie Clare",
                email: "marie@marie.com",
                telephone: "5511999999999",
                establishmentId: 1);

            subsidiary.Remove();
            subsidiary.Restore();

            Assert.True(subsidiary.Available());
        }
    }
}
