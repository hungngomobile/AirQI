using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Core
{
    [BsonIgnoreExtraElements]
    public class Measurement : Document
    {
        [BsonElement]
        public string Parameter { get; set; }

        [BsonElement]
        public double  Value { get; set; }

        [BsonElement]
        public DateTime LastUpdated { get; set; }

        [BsonElement]
        public string Unit { get; set; }
                
        [BsonElement]
        public string SourceName { get; set; }

    }
}