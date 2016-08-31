using System;
using System.Data.Entity;

namespace WebAPI.Infra.Repo.DataContext
{
    public class ContextManager
    {
        #region Fields

        public DbContext Context
        {
            get
            {
                return this.GetConnectionInstance();
            }
        }

        #endregion

        public ContextManager()
        {
        }

        #region Methods

        protected Db GetConnectionInstance()
        {
            return Singleton<Db>.Instance;
        }

        public bool TestDatabase()
        {
            try
            {
                if (!Context.Database.Exists())
                {
                    Console.WriteLine("A conexão com o banco de dados falhou.");
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
