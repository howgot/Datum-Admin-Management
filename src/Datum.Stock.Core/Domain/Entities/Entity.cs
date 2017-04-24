using Datum.Stock.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Core.Domain.Entities
{

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
