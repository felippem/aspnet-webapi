using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace WebAPI.Infra.IoC
{
    public sealed class IoCDependencyResolver : IDependencyResolver
    {
        #region Behaviors

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return IoC.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return IoC.GetAll(serviceType);
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)this;
            
            if (disposable == null) return;

            GC.SuppressFinalize(disposable);
            disposable = null;
        }

        #endregion
    }
}
