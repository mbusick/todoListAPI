using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todoListAPI.Models
{
    public class Todo
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public string Task { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string TodoId { get; set; }
    }
}

