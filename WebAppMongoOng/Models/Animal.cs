using MongoDB.Bson.Serialization.Attributes;

namespace WebAppMongoOng.Models
{
    public class Animal
    {

        [BsonId] //informando minha api que é do tipo json 
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Family { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }

    }
}
