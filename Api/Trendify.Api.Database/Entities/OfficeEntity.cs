using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
namespace Trendify.Api.Database.Entities;

public sealed record OfficeEntity : BaseEntity
{
    public AddressEntity Address { get; set; }
    public OfficeTypes OfficeType { get; set; }



    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();


}