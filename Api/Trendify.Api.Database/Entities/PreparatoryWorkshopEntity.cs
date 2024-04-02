using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record PreparatoryWorkshopEntity : BaseEntity
{
    //Data

    public string Adress { get; set; } = string.Empty;
    public int State { get; set; }

    //Lists

    public List<RollsEntity> Rolls { get; set; } = new List<RollsEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();


}