using System;

namespace WebAPI.Infra.Repo.DataContext
{
    public sealed class Singleton<T> where T : class, new ()
    {
        private Singleton()
        {
        }

        private static readonly Lazy<T> LazyLoad = new Lazy<T>(() => new T());

        public static T Instancia
        {
            get
            {
                return LazyLoad.Value;
            }
        }
    }
}