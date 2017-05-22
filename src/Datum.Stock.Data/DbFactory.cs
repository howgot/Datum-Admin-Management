using Datum.Stock.Data.Context;
using Datum.Stock.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Datum.Stock.Data
{
    public class DbFactory : IDbFactory
    {
        private IMongoDbContext _dbContext;

        public IMongoClient Client => DbContext.Client;

        public IMongoDatabase Database => DbContext.Database;

        public IMongoDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public IMongoDbContext Init()
        {
            return _dbContext ?? (_dbContext = new MongoDbContext());
        }

        public IMongoDbContext Init(string connectionString)
        {
            return _dbContext ?? (_dbContext = new MongoDbContext(connectionString));
        }

        public IMongoDbContext Init(string connectionString, string databaseName)
        {
            return _dbContext ?? (_dbContext = new MongoDbContext(connectionString, databaseName));
        }
    }
}
