using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Data.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>();
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
    }
}
