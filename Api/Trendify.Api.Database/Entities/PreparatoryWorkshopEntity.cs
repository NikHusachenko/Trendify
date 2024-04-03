using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
namespace Trendify.Api.Database.Entities;

public sealed record PreparatoryWorkshopEntity : BaseEntity
{

    public AddressEntity Address { get; set; }
    public States State { get; set; }


    public List<RollEntity> Rolls { get; set; } = new List<RollEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();


}