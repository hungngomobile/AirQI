using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
***REMOVED***
    [BsonIgnoreExtraElements]
    public class Location
    ***REMOVED***
    
        [BsonElement]
        public double Accuracy ***REMOVED*** get; set;***REMOVED***
        
        [BsonElement]
        public double Latitude ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double Longitude ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***