using Datum.Stock.Core.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Datum.Stock.Core.Domain
{
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class Entity : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public virtual DateTime Created { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public virtual DateTime Modified { get; set; }

    }
}
