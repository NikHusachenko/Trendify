using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
namespace Trendify.Api.Database.Entities;

public sealed record ExperimentalWorkshopEntity : BaseEntity
{
    public States State { get; set; }
    public AddressEntity Address { get; set; }


    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();

}