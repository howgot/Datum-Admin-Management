using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datum.Stock.Core.Data
{
    public interface IRepository<T, TKey> : IQueryable<T> where T : IEntity<TKey>
    {
        #region SELECT

        /// <summary>
        /// Returns the T by its given id.
        /// </summary>
        /// <param name="id">The value representing the ObjectId of the entity to retrieve.</param>
        /// <returns>The Entity T.</returns>
        T GetOneById(TKey id);

        /// <summary>
        /// Returns the T by its given id. Async
        /// </summary>
        /// <param name="id">The value representing the ObjectId of the entity to retrieve.</param>
        /// <returns>The Entity T.</returns>
        Task<T> GetOneByIdAsync(TKey id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T GetOne(FilterDefinition<T> filter);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> GetOneAsync(FilterDefinition<T> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<T> GetManyByIds(IEnumerable<TKey> ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetManyByIdsAsync(IEnumerable<TKey> ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(FilterDefinition<T> filter);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        #endregion

        #region INSERT
        /// <summary>
        /// Adds the new entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity including its new ObjectId.</returns>
        void Insert(T entity);

        /// <summary>
        /// Adds the new entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity including its new ObjectId.</returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// Adds the new entities in the repository.
        /// </summary>
        /// <param name="entities">The entities of type T.</param>
        void InsertMany(IEnumerable<T> entities);

        /// <summary>
        /// Adds the new entities in the repository.
        /// </summary>
        /// <param name="entities">The entities of type T.</param>
        Task InsertManyAsync(IEnumerable<T> entities);

        #endregion

        #region UPDATE

        /// <summary>
        /// Upserts an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity.</returns>
        void UpdateOneById(TKey id, UpdateDefinition<T> entity);

        /// <summary>
        /// Upserts an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity.</returns>
        Task UpdateOneByIdAsync(TKey id, UpdateDefinition<T> entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="entity"></param>
        void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="entity"></param>
        Task UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// UpdateMany with ids
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="update"></param>
        void UpdateManyByIds(IEnumerable<string> ids, UpdateDefinition<T> update);

        /// <summary>
        /// UpdateMany with ids
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="update"></param>
        Task UpdateManyByIdsAsync(IEnumerable<string> ids, UpdateDefinition<T> update);


        /// <summary>
        /// UpdateMany with filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        void UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update);

        /// <summary>
        /// UpdateMany with filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);

        #endregion

        #region DELETE
        /// <summary>
        /// Deletes an entity from the repository by its id.
        /// </summary>
        /// <param name="id">The entity's id.</param>
        void DeleteById(TKey id);

        /// <summary>
        /// Deletes an entity from the repository by its id.
        /// </summary>
        /// <param name="id">The entity's id.</param>
        Task DeleteByIdAsync(TKey id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        void DeleteManyById(IEnumerable<string> ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteManyByIdAsync(IEnumerable<string> ids);

        /// <summary>
        /// Deletes all entities in the repository.
        /// </summary>
        void DeleteMany(FilterDefinition<T> filter);

        /// <summary>
        /// Deletes all entities in the repository.
        /// </summary>
        Task DeleteManyAsync(FilterDefinition<T> filter);

        #endregion

        /// <summary>
        /// Counts the total entities in the repository.
        /// </summary>
        /// <returns>Count of entities in the repository.</returns>
        long Count();

        /// <summary>
        /// Counts the total entities in the repository.
        /// </summary>
        /// <returns>Count of entities in the repository.</returns>
        Task<long> CountAsync();

        /// <summary>
        /// Checks if the entity exists for given predicate.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
        bool Exists(T entity);

        /// <summary>
        /// Checks if the entity exists for given predicate.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
        Task<bool> ExistsAsync(T entity);

        /// <summary>
        /// Checks if the entity exists for given predicate.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
        bool Exists(FilterDefinition<T> filter);

        /// <summary>
        /// Checks if the entity exists for given predicate.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
        Task<bool> ExistsAsync(FilterDefinition<T> filter);
    }

    /// <summary>
    /// IRepository definition for default.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository.</typeparam>
    public interface IRepository<T> : IQueryable<T>, IRepository<T, string>
        where T : IEntity<string>
    { }
}
