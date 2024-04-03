using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
namespace Trendify.Api.Database.Entities;

public sealed record UserEntity : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;


    public List<PositionEntity> Positions { get; set; } = new List<PositionEntity>();


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