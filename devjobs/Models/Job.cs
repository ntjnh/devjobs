using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace devjobs.Models;

public class Job
{
    public class Requirements
    {
        [BsonElement("content")]
        public string? Content { get; set; }

        [BsonElement("items")]
        public List<string>? Items { get; set; }
    }
    public class Role
    {
        [BsonElement("content")]
        public string? Content { get; set; }

        [BsonElement("items")]
        public List<string>? Items { get; set; }
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("company")]
    public string? Company { get; set; }

    public string? Logo { get; set; }

    [BsonElement("logoBackground")]
    public string? LogoBackground { get; set; }

    [BsonElement("position")]
    [JsonPropertyName("position")]
    public string? Position { get; set; }
    
    [BsonElement("postedAt")]
    public string? PostedAt { get; set; }
    
    [BsonElement("contract")]
    public string? Contract { get; set; }
    
    [BsonElement("location")]
    public string? Location { get; set; }
    
    [BsonElement("website")]
    public string? Website { get; set; }
    
    [BsonElement("apply")]
    public string? Apply { get; set; }
    
    [BsonElement("description")]
    public string? Description { get; set; }
    
    [BsonElement("requirements")]
    public Requirements? JobRequirements { get; set; }
    
    [BsonElement("role")]
    public Role? JobRole { get; set; }
}
