using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
namespace Trendify.Api.Database.Entities;

public sealed record CuttingWorkshopEntity : BaseEntity
{
    public States State { get; set; }
    public string Address { get; set; } = string.Empty;


    public List<CuttingsEntity> Cuttings { get; set; } = new List<CuttingsEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();



}