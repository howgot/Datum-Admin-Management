using Datum.Stock.Core.Domain;

namespace Datum.Stock.Core.Events
{
    public class EntityDeleted<T> where T : Entity
    {
        public T Entity { get; private set; }

        public EntityDeleted(T entity)
        {
            this.Entity = entity;
        }
    }
}
