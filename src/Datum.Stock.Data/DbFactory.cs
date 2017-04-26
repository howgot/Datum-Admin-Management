using Datum.Stock.Data.Context;
using Datum.Stock.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Data
{
    public class DbFactory : IDbFactory
    {
        private MongoDbContext _dbContext;

        public MongoDbContext Init()
        {
            return _dbContext ?? (_dbContext = new MongoDbContext());
        }
    }
}
