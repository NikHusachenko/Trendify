using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record CuttingWorkshopEntity : BaseEntity
{
    public States State { get; set; }

    public Guid AddressId { get; set; }
    public AddressEntity Address { get; set; }

    public List<CuttingsEntity> Cuttings { get; set; } = new List<CuttingsEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();
}