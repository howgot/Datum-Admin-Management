using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Datum.Stock.Core.Entities
{
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the Id of the Entity.
        /// </summary>
        /// <value>Id of the Entity.</value>
        [BsonId]
        TKey Id { get; set; }

        DateTime Created { get; set; }

        DateTime Modified { get; set; }

    }

    /// <summary>
    /// "Default" Entity interface.
    /// </summary>
    /// <remarks>Entities are assumed to use strings for Id's.</remarks>
    public interface IEntity : IEntity<string>
    {

    }
}
