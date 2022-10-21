using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAppMongoOng.Models
{
    public class Person
    {
        [BsonId] //informando minha api que é do tipo json 
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Animal Animal { get; set; }

    }
}
