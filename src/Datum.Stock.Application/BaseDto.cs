using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Application
{
    public abstract class BaseDto
    {
        public virtual string Id { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual DateTime Modified { get; set; }
    }
}
