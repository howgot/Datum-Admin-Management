using Autofac;
using Datum.Stock.Web.Framework.DependecyInjection;

namespace Datum.Stock.Tests
{
    public abstract class BaseTest
    {
        public bool CleanUp { get; set; }

        protected IContainer container = null;
        
    
        public BaseTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ApplicationModule());

            container = builder.Build();
        }

       
    }
}
