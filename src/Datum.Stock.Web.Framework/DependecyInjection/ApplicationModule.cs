using Autofac;
using Datum.Stock.Application;
using Datum.Stock.Core.Domain;

namespace Datum.Stock.Web.Framework.DependecyInjection
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register Repository Module
            builder.RegisterModule(new RepositoryModule());

            //Application Services

            base.Load(builder);
        }
    }
}
