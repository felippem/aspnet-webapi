using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Infra.IoC;
using WebAPI.Infra.Repo.DataContext;

namespace WebAPI.Test
{
    [TestClass]
    public class ContextManagerTest
    {
        public ContextManagerTest()
        {
            IoC.Init();
        }

        [TestMethod]
        public void Possui_conexao_com_o_banco_de_dados()
        {
            Assert.AreEqual(true, new ContextManager().TestDatabase());
        }
    }
}
