using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eKarton.Models
{
    public class Book
    {
        [BsonId] //documents primary key
        [BsonRepresentation(BsonType.ObjectId)]//to allow passing the parameter as type string instead of an ObjectId structure.Mongo handles the conversion from string to ObjectId.
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
