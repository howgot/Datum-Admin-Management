using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Core.Domain.Article
{
    public class Article : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Published { get; set; }
        
    }
}
