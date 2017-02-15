using System;

namespace SharedKernel
{
    public sealed class Singleton<T> where T : class, new ()
    {
        private Singleton()
        {
        }

        private static readonly Lazy<T> LazyLoad = new Lazy<T>(() => new T());

        public static T Instance
        {
            get
            {
                return LazyLoad.Value;
            }
        }
    }
}