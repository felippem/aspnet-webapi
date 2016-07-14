using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Application;
using WebAPI.Domain.Entities;
using WebAPI.Infra.IoC;

namespace WebAPI.Test
{
    [TestClass]
    public class EstablishmentApplicationTest
    {
        private EstablishmentApplication _establishmentApplication;
        
        public EstablishmentApplicationTest()
        {
            IoC.Init();

            _establishmentApplication = ServiceLocator.Current.GetInstance<EstablishmentApplication>();
        }

        [TestMethod]
        public void Devo_receber_uma_enumerable_de_estabelecimentos()
        {
            Assert.IsInstanceOfType(_establishmentApplication.List(), typeof(IEnumerable<Establishment>));
        }
    }
}
