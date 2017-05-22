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
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //General
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<MongoClient>().As<IMongoClient>();
            builder.RegisterType<MongoDatabaseBase>().As<IMongoDatabase>();
            builder.RegisterType<MongoDbContext>().As<IMongoDbContext>();
            builder.RegisterGeneric(typeof(MongoCollectionBase<>)).As(typeof(IMongoCollection<>));
            
            //Repositories
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));

            base.Load(builder);
        }
    }
}
