using System;
using System.Data.Entity;
using System.Web;

namespace WebAPI.Infra.Repo.DataContext
{
    public class ContextManager
    {
        #region Constants

        protected const string CONTEXT_KEY = "ContextManager.Key";

        #endregion

        #region Properties

        public DbContext Context
        {
            get
            {
                if (HttpContext.Current == null)
                    return this.GetConnectionInstance();

                if (HttpContext.Current.Items[CONTEXT_KEY] == null)
                    HttpContext.Current.Items[CONTEXT_KEY] = this.GetConnectionInstance();
                return (DbContext)HttpContext.Current.Items[CONTEXT_KEY];
            }
        }

        #endregion

        #region Methods

        protected Db GetConnectionInstance()
        {
            // TO DO: Ler connectionstring criptograda, descriptografar e passar como parâmetro.
            return new Db();
        }

        public bool TestDatabase()
        {
            try
            {
                if (!Context.Database.Exists())
                {
                    Console.WriteLine("Não foi possível localizar o banco de dados");
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
