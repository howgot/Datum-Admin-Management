using System;
using MongoDB.Driver;
using Datum.Stock.Data.Interfaces;
using Datum.Stock.Core;

namespace Datum.Stock.Data.Context
{
    public class MongoDbContext : IMongoDbContext
    {

        public IMongoClient Client { get; }
        public IMongoDatabase Database { get; }

        internal MongoDbContext()
        {
            var mongoUrl = new MongoUrl(StockConsts.DEFAULT_CONNECTION_STRING);
            Client = new MongoClient(mongoUrl);
            Database = Client.GetDatabase(mongoUrl.DatabaseName);
        }

        public MongoDbContext(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            Client = new MongoClient(mongoUrl);
            Database = Client.GetDatabase(mongoUrl.DatabaseName);
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            var mongoUrl = new MongoUrl(connectionString);
            Client = new MongoClient(mongoUrl);
            Database = Client.GetDatabase(databaseName);
        }


        /// <summary>
        /// The private GetCollection method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return Database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "_list");
        }
    }
}
