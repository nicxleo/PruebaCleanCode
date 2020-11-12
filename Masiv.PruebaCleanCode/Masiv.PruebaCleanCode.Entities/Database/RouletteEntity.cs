﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Masiv.PruebaCleanCode.Entities.Database
{
    public class RouletteEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string State { get; set; }
        public string Date { get; set; }
    }
}