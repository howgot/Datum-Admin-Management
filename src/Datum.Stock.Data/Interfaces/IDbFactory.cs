using Datum.Stock.Data.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Data.Interfaces
{
    public interface IDbFactory
    {
        IMongoDbContext Init();

        IMongoDbContext Init(string connectionString);

        IMongoDbContext Init(string connectionString, string databaseName);

        IMongoDbContext DbContext { get; }

        IMongoClient Client { get; }

        IMongoDatabase Database { get; }
    }
}
