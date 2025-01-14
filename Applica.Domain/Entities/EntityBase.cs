using MongoDB.Bson;

namespace Applica.Domain.Entities;

public class EntityBase
{
    public ObjectId Id { get; set; }
}
