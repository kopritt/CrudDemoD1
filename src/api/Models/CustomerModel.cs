using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestApiCrudDemo.Models
{
    public class CustomerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string CustomerName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; } = null!;

        public List<SocialMedia> SocialMedias = new List<SocialMedia>();

        public string Cpf { get; set; }

        public string Rg { get; set; }
    }

    public class SocialMedia
    {
        public string MediaName { get; set; }

        public string MediaUrl { get; set; }
    }
}
