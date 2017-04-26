using Datum.Stock.Data.Context;
using Datum.Stock.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Data
{
    public class DbFactory : IDbFactory
    {
        private IMongoDbContext _dbContext;

        public IMongoDbContext Init()
        {
            return _dbContext ?? (_dbContext = new MongoDbContext());
        }
    }
}
