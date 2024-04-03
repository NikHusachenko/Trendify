namespace Trendify.Api.Database.Entities;

public sealed record AddressEntity : BaseEntity
{
    public string Country { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int Building { get; set; }
    public string AdditionalAddress { get; set; } = string.Empty;
    public int? Flat { get; set; }

    public Guid? OfficeId { get; set; }
    public OfficeEntity Office { get; set; }

    public Guid? PreparatoryWorkshopId { get; set; }
    public PreparatoryWorkshopEntity PreparatoryWorkshop { get; set; }

    public Guid? CuttingWorkshopId { get; set; }
    public CuttingWorkshopEntity CuttingWorkshop { get; set; }

    public Guid? ExperimentalWorkshopId { get; set; }
    public ExperimentalWorkshopEntity ExperimentalWorkshop { get; set; }

    public Guid? SewingWorkshopId { get; set; }
    public SewingWorkshopEntity SewingWorkshop { get; set; }

    public Guid? WarehouseId { get; set; }
    public WarehouseEntity Warehouse { get; set; }
}