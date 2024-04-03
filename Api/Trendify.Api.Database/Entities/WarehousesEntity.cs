using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record WarehouseEntity : BaseEntity
{
    //Data

    public int State { get; set; }
    public string Address { get; set; } = string.Empty;


    //Lists

    public List<ProductsEntity> Products { get; set; } = new List<ProductsEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();

}