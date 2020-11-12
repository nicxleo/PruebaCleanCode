using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Masiv.PruebaCleanCode.Entities.Database
{
    public class BetEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RouletteId { get; set; }
        public string UserId { get; set; }
        public int? Number { get; set; }
        public string Color { get; set; }
        public decimal Amount { get; set; }
    }
}