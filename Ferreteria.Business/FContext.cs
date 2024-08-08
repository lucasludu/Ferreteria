using Ferreteria.Models;
using System;

namespace Ferreteria.Business
{
    public abstract class FContext : IDisposable
    {

        protected FerreteriaEntities Context;


        protected FContext()
        {
            this.Context = new FerreteriaEntities(StringConnection.ConnectionString);
            this.Context.Configuration.ProxyCreationEnabled = false;
            this.Context.Configuration.LazyLoadingEnabled = false;
            this.Context.Configuration.AutoDetectChangesEnabled = false;
        }


        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
