using Autofac;
using Datum.Stock.Application;
using Datum.Stock.Application.Authorization;
using Datum.Stock.Application.Authorization.Validators;
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
            builder.RegisterType<AccountService>().As<IAccountService>();

            //Validators
            builder.RegisterType<UserValidator>().AsSelf();
            builder.RegisterType<RoleValidator>().AsSelf();

            //Managers
            builder.RegisterType<UserManager>().AsSelf();

            base.Load(builder);
        }
    }
}
