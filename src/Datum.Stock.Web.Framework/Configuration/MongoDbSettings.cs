using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Web.Framework.Configuration
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string UserDatabase { get; set; }
        public string ContentDatabase { get; set; }
    }
}
