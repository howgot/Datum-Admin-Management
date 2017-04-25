using Datum.Stock.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Data.Interfaces
{
    public interface IDbFactory
    {
        MongoDbContext Init();
    }
}
