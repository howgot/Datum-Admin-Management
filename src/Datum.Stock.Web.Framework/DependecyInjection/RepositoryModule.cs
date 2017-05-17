using Autofac;
using MongoDB.Driver;
using Datum.Stock.Data;
using Datum.Stock.Data.Interfaces;
using Datum.Stock.Data.Repositories;
using Datum.Stock.Core;
using Datum.Stock.Data.Context;
using Datum.Stock.Core.Data;

namespace Datum.Stock.Web.Framework.DependecyInjection
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //General
            builder.RegisterType<MongoClient>().As<IMongoClient>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<MongoDbContext>().As<IMongoDbContext>();

            //Repositories
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));

            base.Load(builder);
        }
    }
}
