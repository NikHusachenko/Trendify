using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record CuttingsEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Count { get; set; }
    public string Color { get; set; } = string.Empty;
    public int RAL { get; set; }
    public CuttingTypes CuttingType { get; set; }

    public Guid CuttingWorkshopId { get; set; }
    public CuttingWorkshopEntity CuttingWorkshop { get; set; }
}