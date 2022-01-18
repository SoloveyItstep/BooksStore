using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Books.Domain.Core.DbEntities
{
    public class Favorites
    {
        [BsonId]
        public string Id { get; set; }
        //public ObjectId  Id { get; set; }
        public string UserID { get; set; }
        public IEnumerable<string> BooksIDs  { get; set; }
    }
}
