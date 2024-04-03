using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record CuttingWorkshopEntity : BaseEntity
{
    //Data

    public int State { get; set; }
    public string Address { get; set; } = string.Empty;

    //Lists

    public List<CuttingsEntity> Cutting { get; set; } = new List<CuttingsEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();



}