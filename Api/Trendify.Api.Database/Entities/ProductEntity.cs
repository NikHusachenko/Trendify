using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record ProductEntity : BaseEntity
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string WorkNeeded { get; set; } = string.Empty;
    public string MaterialsIsNeeded { get; set; } = string.Empty;
    public float Rate { get; set; }
    public int Count { get; set; }
    public int RAL { get; set; }
    public string Color { get; set; } = string.Empty;
    public Currency Currency { get; set; }
    public float Price { get; set; }


    public Guid SewingWorkshopId { get; set; }
    public Guid WarehouseId { get; set; }

    public SewingWorkshopEntity SewingWorkshop { get; set; }
    public WarehouseEntity Warehouse { get; set; }
}