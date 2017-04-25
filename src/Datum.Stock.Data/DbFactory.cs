using Datum.Stock.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Data
{
    public class DbFactory
    {
        private MongoDbContext _dbContext;

        public MongoDbContext Init()
        {
            return _dbContext ?? (_dbContext = new MongoDbContext());
        }
    }
}
