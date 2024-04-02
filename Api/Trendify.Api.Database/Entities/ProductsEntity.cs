using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record ProductsEntity : BaseEntity
{
    //Data

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string WorkNeeded { get; set; } = string.Empty;
    public string MaterialsIsNeeded { get; set; } = string.Empty;
    public float Rate { get; set; }
    public int Count { get; set; }
    public int RAL { get; set; }
    public string Color { get; set; } = string.Empty;
    public int Currency { get; set; }
    public float Price { get; set; }

    //Foreign keys

    public Guid WarehouseId { get; set; }

}