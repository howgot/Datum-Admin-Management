using System;
using MongoDB.Driver;
using Datum.Stock.Data.Interfaces;

namespace Datum.Stock.Data.Context
{
    public class MongoDbContext: IMongoDbContext
    {
        public static readonly IMongoClient Client;
        public static readonly IMongoDatabase Database;

        static MongoDbContext()
        {
            var connectionString = "mongodb://localhost:27017/StockDb?readPreference=primary"; //Core.StockConsts.ConnectionStringName;
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
            return Database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
        }
    }
}
