using Datum.Stock.Core;

namespace Datum.Stock.Application
{
    public abstract class BaseService<TEntity, TKey>
    {

        protected BaseService()
        {

        }



    }

    /// <summary>
    /// Deals with entities in MongoDb.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository.</typeparam>
    /// <remarks>Entities are assumed to use strings for Id's.</remarks>
    public class BaseService<T> : BaseService<T, string> where T : IEntity<string>
    {
       
    }
}
