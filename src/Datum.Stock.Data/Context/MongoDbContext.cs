using System;
using MongoDB.Driver;

namespace Datum.Stock.Data.Context
{
    public class MongoDbContext
    {
        public static readonly IMongoClient Client;
        public static readonly IMongoDatabase Database;

        static MongoDbContext()
        {
            var connectionString = Core.StockConsts.ConnectionStringName;
            var mongoUrl = new MongoUrl(connectionString);
            Client = new MongoClient(mongoUrl);
            Database = Client.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// The private GetCollection method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return Database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "_collection");
        }
    }
}
