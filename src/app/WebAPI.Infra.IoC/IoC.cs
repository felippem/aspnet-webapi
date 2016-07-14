using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Collections.Generic;

namespace WebAPI.Infra.IoC
{
    public class IoC
    {
        #region Fields

        private static StandardKernel _kernel;

        #endregion

        #region Behaviors

        public static void Init()
        {
            _kernel = new StandardKernel(new IoCModule());

            /// Na impossibilidade de ultilizar a instância provida através da injeção de dependência,
            /// é possível localizar a mesma através do CommonServiceLocator.
            /// Para adicionar o CommonServiceLocator ao projeto, realize a instalação através do Nuget:
            /// -> PM> install-package CommonServiceLocator
            /// Sendo assim, para o funcionamento de tal mecanismo é necessário que o kernel do provedor 
            /// das dependências seja configurado.
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(_kernel));
        }

        public static object Get(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public static IEnumerable<object> GetAll(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        #endregion
    }
}
