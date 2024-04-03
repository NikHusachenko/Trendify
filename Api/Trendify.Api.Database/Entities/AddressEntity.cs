using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
namespace Trendify.Api.Database.Entities;

public sealed record AddressEntity : BaseEntity
{
    public string Country { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Building { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string Flat { get; set; } = string.Empty;

    public Guid OfficeId { get; set; }
    public Guid PreparatoryWorkshopId { get; set; }
    public Guid CuttingWorkshopId { get; set; }
    public Guid ExperimentalWorkshopId { get; set; }
    public Guid SewingWorkshopId { get; set; }
    public Guid WarehouseId { get; set; }

    public OfficeEntity Office { get; set; }
    public ExperimentalWorkshopEntity ExperimentalWorkshop { get; set; }
    public PreparatoryWorkshopEntity PreparatoryWorkshop { get; set; }
    public CuttingWorkshopEntity CuttingWorkshop { get; set; }
    public SewingWorkshopEntity SewingWorkshop { get; set; }
    public WarehouseEntity Warehouse { get; set; }


}