using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Datum.Stock.Core.Entities;

namespace Datum.Stock.Application
{
    public abstract class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        private readonly IBaseService<TEntity, TKey> _baseService;

        protected BaseService(IBaseService<TEntity, TKey> baseService)
        {
            _baseService = baseService;
        }


        public IEnumerator<TEntity> GetEnumerator()
        {
            return _baseService.AsEnumerable<TEntity>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression { get; }

        public Type ElementType { get; }

        public IQueryProvider Provider { get; }


        public TEntity GetOneById(TKey id)
        {
            return _baseService.GetOneById(id);
        }

        public async Task<TEntity> GetOneByIdAsync(TKey id)
        {
            return await _baseService.GetOneByIdAsync(id);
        }

        public TEntity GetOne(FilterDefinition<TEntity> filter)
        {
            return _baseService.GetOne(filter);
        }

        public async Task<TEntity> GetOneAsync(FilterDefinition<TEntity> filter)
        {
            return await _baseService.GetOneAsync(filter);
        }

        public IEnumerable<TEntity> GetManyByIds(IEnumerable<TKey> ids)
        {
            return _baseService.GetManyByIds(ids);
        }

        public async Task<IEnumerable<TEntity>> GetManyByIdsAsync(IEnumerable<TKey> ids)
        {
            return await _baseService.GetManyByIdsAsync(ids);
        }

        public IEnumerable<TEntity> GetMany(FilterDefinition<TEntity> filter)
        {
            return _baseService.GetMany(filter);
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(FilterDefinition<TEntity> filter)
        {
            return await _baseService.GetManyAsync(filter);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseService.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _baseService.GetAllAsync();
        }

        public void Add(TEntity entity)
        {
            _baseService.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _baseService.AddAsync(entity);
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            _baseService.AddMany(entities);
        }

        public async Task AddManyAsync(IEnumerable<TEntity> entities)
        {
            await _baseService.AddManyAsync(entities);
        }

        public void UpdateOneById(TKey id, UpdateDefinition<TEntity> entity)
        {
            _baseService.UpdateOneById(id, entity);
        }

        public async Task UpdateOneByIdAsync(TKey id, UpdateDefinition<TEntity> entity)
        {
            await _baseService.UpdateOneByIdAsync(id, entity);
        }

        public void UpdateOne(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> entity)
        {
            _baseService.UpdateOne(filter, entity);
        }

        public async Task UpdateOneAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> entity)
        {
            await _baseService.UpdateOneAsync(filter, entity);
        }

        public void UpdateManyByIds(IEnumerable<string> ids, UpdateDefinition<TEntity> update)
        {
            _baseService.UpdateManyByIds(ids, update);
        }

        public async Task UpdateManyByIdsAsync(IEnumerable<string> ids, UpdateDefinition<TEntity> update)
        {
            await _baseService.UpdateManyByIdsAsync(ids, update);
        }

        public void UpdateMany(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            _baseService.UpdateMany(filter, update);
        }

        public async Task UpdateManyAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            await _baseService.UpdateManyAsync(filter, update);
        }

        public void DeleteById(TKey id)
        {
            _baseService.DeleteById(id);
        }

        public async Task DeleteByIdAsync(TKey id)
        {
            await _baseService.DeleteByIdAsync(id);
        }

        public void DeleteManyById(IEnumerable<string> ids)
        {
            _baseService.DeleteManyById(ids);
        }

        public async Task DeleteManyByIdAsync(IEnumerable<string> ids)
        {
            await _baseService.DeleteManyByIdAsync(ids);
        }

        public void DeleteMany(FilterDefinition<TEntity> filter)
        {
            _baseService.DeleteMany(filter);
        }

        public async Task DeleteManyAsync(FilterDefinition<TEntity> filter)
        {
            await _baseService.DeleteManyAsync(filter);
        }

        public long Count()
        {
            return _baseService.Count();
        }

        public async Task<long> CountAsync()
        {
            return await _baseService.CountAsync();
        }

        public bool Exists(TEntity entity)
        {
            return _baseService.Exists(entity);
        }

        public async Task<bool> ExistsAsync(TEntity entity)
        {
            return await _baseService.ExistsAsync(entity);
        }

        public bool Exists(FilterDefinition<TEntity> filter)
        {
            return _baseService.Exists(filter);
        }

        public async Task<bool> ExistsAsync(FilterDefinition<TEntity> filter)
        {
            return await _baseService.ExistsAsync(filter);
        }
    }

    /// <summary>
    /// Deals with entities in MongoDb.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository.</typeparam>
    /// <remarks>Entities are assumed to use strings for Id's.</remarks>
    public class BaseService<T> : BaseService<T, string>, IBaseService<T>
        where T : IEntity<string>
    {

        public BaseService(IBaseService<T> baseService) : base(baseService)
        {
        }
    }
}
