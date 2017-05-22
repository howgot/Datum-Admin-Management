using AspNetCore.Identity.MongoDB;
using Autofac;
using Datum.Stock.Application;
using Datum.Stock.Application.Authorization;
using Datum.Stock.Application.Authorization.Validators;
using Datum.Stock.Core.Domain;
using Datum.Stock.Core.Domain.Authorization;
using Datum.Stock.Data;
using Datum.Stock.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Datum.Stock.Web.Framework.DependecyInjection
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register Repository Module
            builder.RegisterModule(new DataModule());

            //Managers
            builder.Register(c => new MongoUserStore<User>(c.Resolve<IDbFactory>().Init().Database)).As<MongoUserStore<User>>().SingleInstance();
           
            //Validators
            builder.RegisterType<UserValidator>().AsSelf();

            //Application Services
            builder.RegisterType<AccountService>().As<IAccountService>();




            base.Load(builder);
        }
    }
}
