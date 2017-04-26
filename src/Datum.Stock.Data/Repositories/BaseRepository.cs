using Datum.Stock.Core.Domain;
using Datum.Stock.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Datum.Stock.Data.Context;
using Datum.Stock.Data.Interfaces;

namespace Datum.Stock.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        #region Properties

        private MongoDbContext _dbContext;
        private IMongoCollection<TEntity> _entities;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }


        protected MongoDbContext DbContext => _dbContext ?? (_dbContext = DbFactory.Init());

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IMongoCollection<TEntity> Entities => _entities ?? (_entities = DbContext.GetCollection<TEntity>());

        #endregion

        #region C'tor
        /// <summary>
        /// Initializes a new instance of the MongoRepository class.
        /// Uses the Default App/Web.Config connectionstrings to fetch the connectionString and Database name.
        /// </summary>
        /// <remarks>Default constructor defaults to "MongoServerSettings" key for connectionstring.</remarks>
        public BaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Entities.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression { get; }

        public Type ElementType { get; }

        public IQueryProvider Provider { get; }

        #endregion

        #region Methods

        #region SELECT
        public virtual TEntity GetOneById(TKey id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return Entities.Find(filter).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneByIdAsync(TKey id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return await Entities.Find(filter).SingleOrDefaultAsync();
        }

        public virtual TEntity GetOne(FilterDefinition<TEntity> filter)
        {
            return Entities.Find(filter).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync(FilterDefinition<TEntity> filter)
        {
            return await Entities.Find(filter).SingleOrDefaultAsync();
        }

        public virtual IEnumerable<TEntity> GetManyByIds(IEnumerable<TKey> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var filter = Builders<TEntity>.Filter.In("Id", ids);

            return Entities.Find(filter).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyByIdsAsync(IEnumerable<TKey> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var filter = Builders<TEntity>.Filter.In("Id", ids);

            return await Entities.Find(filter).ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetMany(FilterDefinition<TEntity> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return Entities.Find(filter).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(FilterDefinition<TEntity> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return await Entities.Find(filter).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Entities.Find(Builders<TEntity>.Filter.Empty).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.Find(Builders<TEntity>.Filter.Empty).ToListAsync();
        }

        #endregion

        #region INSERT

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //Set Created and Modified 
            entity.Created = DateTime.UtcNow;

            entity.Modified = entity.Created;

            Entities.InsertOne(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //Set Created and Modified 
            entity.Created = DateTime.UtcNow;

            entity.Modified = entity.Created;

            await Entities.InsertOneAsync(entity);
        }

        public virtual void AddMany(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var updatedEntities = entities.AsEnumerable().Select(e =>
            {
                e.Created = DateTime.UtcNow;
                e.Modified = e.Created;
                return e;
            });

            Entities.InsertMany(updatedEntities);
        }

        public virtual async Task AddManyAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var updatedEntities = entities.AsEnumerable().Select(e =>
            {
                e.Created = DateTime.UtcNow;
                e.Modified = e.Created;
                return e;
            });

            await Entities.InsertManyAsync(updatedEntities);
        }

        #endregion

        #region UPDATE

        public virtual void UpdateOneById(TKey id, UpdateDefinition<TEntity> updateDefinition)
        {
            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            var filter = new FilterDefinitionBuilder<TEntity>().Eq("Id", id);

            //Set Modified
            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);


            var result = Entities.UpdateOne(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");
        }

        public virtual async Task UpdateOneByIdAsync(TKey id, UpdateDefinition<TEntity> updateDefinition)
        {
            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            var filter = new FilterDefinitionBuilder<TEntity>().Eq("Id", id);


            //Set Modified 
            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);

            var result = await Entities.UpdateOneAsync(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");
        }

        public virtual void UpdateOne(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            //Set Modified 
            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);

            var result = Entities.UpdateOne(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");

        }

        public virtual async Task UpdateOneAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            //Set Modified 
            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);

            var result = await Entities.UpdateOneAsync(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");
        }

        public virtual void UpdateManyByIds(IEnumerable<string> ids, UpdateDefinition<TEntity> updateDefinition)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            var filter = new FilterDefinitionBuilder<TEntity>().In("Id", ids);

            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);

            var result = Entities.UpdateMany(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");
        }

        public virtual async Task UpdateManyByIdsAsync(IEnumerable<string> ids, UpdateDefinition<TEntity> updateDefinition)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            var filter = new FilterDefinitionBuilder<TEntity>().In("Id", ids);

            //Set Modified 
            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);

            var result = await Entities.UpdateManyAsync(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");
        }

        public virtual void UpdateMany(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            //Set Modified 
            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);

            var result = Entities.UpdateMany(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");
        }

        public virtual async Task UpdateManyAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (updateDefinition == null)
                throw new ArgumentNullException(nameof(updateDefinition));

            //Set Modified 
            var updatedWithModified = updateDefinition.Set(e => e.Modified, DateTime.UtcNow);

            var result = await Entities.UpdateManyAsync(filter, updatedWithModified);

            if (result.ModifiedCount < 1)
                throw new ArgumentException("No update occured");
        }

        #endregion

        #region DELETE


        public virtual void DeleteById(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var filter = new FilterDefinitionBuilder<TEntity>().Eq("Id", id);

            var result = Entities.DeleteOne(filter);

            if (result.DeletedCount < 1)
                throw new ArgumentException("No delete occured");
        }

        public virtual async Task DeleteByIdAsync(TKey id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var filter = new FilterDefinitionBuilder<TEntity>().Eq("Id", id);

            var result = await Entities.DeleteOneAsync(filter);

            if (result.DeletedCount < 1)
                throw new ArgumentException("No delete occured");
        }


        public virtual void DeleteManyById(IEnumerable<string> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var filter = new FilterDefinitionBuilder<TEntity>().Eq("Id", ids);

            var result = Entities.DeleteMany(filter);

            if (result.DeletedCount < 1)
                throw new ArgumentException("No delete occured");
        }

        public virtual async Task DeleteManyByIdAsync(IEnumerable<string> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var filter = new FilterDefinitionBuilder<TEntity>().Eq("Id", ids);

            var result = await Entities.DeleteManyAsync(filter);

            if (result.DeletedCount < 1)
                throw new ArgumentException("No delete occured");
        }
        public virtual void DeleteMany(FilterDefinition<TEntity> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var result = Entities.DeleteMany(filter);

            if (result.DeletedCount < 1)
                throw new ArgumentException("No delete occured");
        }
        public virtual async Task DeleteManyAsync(FilterDefinition<TEntity> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var result = await Entities.DeleteManyAsync(filter);

            if (result.DeletedCount < 1)
                throw new ArgumentException("No delete occured");
        }
        #endregion

        public virtual long Count()
        {
            var filter = Builders<TEntity>.Filter.Exists("Id", true);


            return Entities.Count(filter);
        }

        public virtual async Task<long> CountAsync()
        {
            var filter = Builders<TEntity>.Filter.Exists("Id", true);

            return await Entities.CountAsync(filter);
        }

        public virtual bool Exists(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);

            return Entities.Count(filter) > 0;
        }

        public virtual async Task<bool> ExistsAsync(TEntity entity)
        {

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);

            return await Entities.CountAsync(filter) > 0;
        }

        public virtual bool Exists(FilterDefinition<TEntity> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return Entities.Count(filter) > 0;
        }

        public virtual async Task<bool> ExistsAsync(FilterDefinition<TEntity> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return await Entities.CountAsync(filter) > 0;
        }

        #endregion
    }

    /// <summary>
    /// Deals with entities in MongoDb.
    /// </summary>
    /// <typeparam name="TEntity">The type contained in the repository.</typeparam>
    /// <remarks>Entities are assumed to use strings for Id's.</remarks>
    public class BaseRepository<TEntity> : BaseRepository<TEntity, string>, IRepository<TEntity>
        where TEntity : IEntity<string>
    {
        public BaseRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
