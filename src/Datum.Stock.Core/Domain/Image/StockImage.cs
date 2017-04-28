using Datum.Stock.Core.Domain.Authorization;
using System.Collections.Generic;

namespace Datum.Stock.Core.Domain.Image
{
    public class StockImage : Entity
    {
        public StockImage()
        {
            Metadata = new Dictionary<string, string>();
        }
 
        public string Title { get; set; }

        public string Description { get; set; }

        public long Size { get; set; }

        public string Extension { get; set; }

        public string MimeType { get; set; }

        public IDictionary<string, string> Metadata { get; set; }

        public User CreatedBy { get; set; }

        public User ModifiedBy { get; set; }

    }
}
