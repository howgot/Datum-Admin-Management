using Datum.Stock.Core.Data;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Datum.Stock.Core.Configuration
{
    public abstract class MongoMapper<TEntity> : IMongoMapper<TEntity> where TEntity : IEntity
    {
        private static bool _initialized = false;
        private static object _initializationLock = new object();
        private static object _initializationTarget;

        public void EnsureConfigured()
        {
            LazyInitializer.EnsureInitialized(ref _initializationTarget, ref _initialized, ref _initializationLock, () =>
            {
                Configure();
                return null;
            });
        }

        public virtual void Configure()
        {
            RegisterConventions();

            //Mapping here
        }

        private static void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreIfNullConvention(false),
                new CamelCaseElementNameConvention(),
            };

            ConventionRegistry.Register("Howgot.Datum.Stock", pack, IsConventionApplicable);
        }

        private static bool IsConventionApplicable(Type type)
        {
            return type == typeof(IEntity);

        }
    }
}
