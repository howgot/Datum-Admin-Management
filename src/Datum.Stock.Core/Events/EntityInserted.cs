using Datum.Stock.Core.Domain;

namespace Datum.Stock.Core.Events
{
    public class EntityInserted<T> where T:Entity
    {
        public T Entity { get; set; }

        public EntityInserted(T entity)
        {
            this.Entity = entity;
        }
    }
}
