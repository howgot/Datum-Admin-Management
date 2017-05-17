using Datum.Stock.Core.Domain;

namespace Datum.Stock.Core.Events
{
    public class EntityUpdated<T> where T:Entity
    {
        public T Entity { get; private set; }

        public EntityUpdated(T entity)
        {
            this.Entity = entity;
        }
    }
}
