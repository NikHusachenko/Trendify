using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record UserEntity : BaseEntity
{
    //Data

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;

    //Lists
    public List<PositionsEntity> Positions { get; set; } = new List<PositionsEntity>();

    //Foreig keys

    public Guid OfficeId { get; set; }
    public Guid PreparatoryWorkshopId { get; set; }
    public Guid CuttingWorkshopId { get; set; }
    public Guid ExperimentalWorkshopId { get; set; }
    public Guid SewingWorkshopId { get; set; }
    public Guid WarehouseId { get; set; }

}