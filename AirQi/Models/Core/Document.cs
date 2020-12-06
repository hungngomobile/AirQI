using System;
using MongoDB.Bson;
using AirQi.Models;

namespace AirQi.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
                
        public Coordinates Coordinates { get; set; }
    }
}