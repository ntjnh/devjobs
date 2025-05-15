using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace devjobs.Models;

public class Job
{
    public class Requirements
    {
        [BsonElement("content")]
        [NotNull]
        public string? Content { get; set; }

        [BsonElement("items")]
        [NotNull]
        public List<string>? Items { get; set; }
    }
    public class Role
    {
        [BsonElement("content")]
        [NotNull]
        public string? Content { get; set; }

        [BsonElement("items")]
        [NotNull]
        public List<string>? Items { get; set; }
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("company")]
    [NotNull]
    public string? Company { get; set; }

    [BsonElement("logo")]
    [NotNull]
    public string? Logo { get; set; }

    [BsonElement("logoBackground")]
    [NotNull]
    public string? LogoBackground { get; set; }

    [BsonElement("position")]
    [JsonPropertyName("position")]
    [NotNull]
    public string? Position { get; set; }
    
    [BsonElement("postedAt")]
    [NotNull]
    public string? PostedAt { get; set; }
    
    [BsonElement("contract")]
    [NotNull]
    public string? Contract { get; set; }
    
    [BsonElement("location")]
    [NotNull]
    public string? Location { get; set; }
    
    [BsonElement("website")]
    [NotNull]
    public string? Website { get; set; }
    
    [BsonElement("apply")]
    [NotNull]
    public string? Apply { get; set; }
    
    [BsonElement("description")]
    [NotNull]
    public string? Description { get; set; }
    
    [BsonElement("requirements")]
    public Requirements? JobRequirements { get; set; }
    
    [BsonElement("role")]
    public Role? JobRole { get; set; }
}
