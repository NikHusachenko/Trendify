using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record SewingWorkshopEntity : BaseEntity
{
    //Data

    public string Address { get; set; } = string.Empty;
    public int State { get; set; }

    //Lists

    public List<ProductsEntity> Products { get; set; } = new List<ProductsEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();

}