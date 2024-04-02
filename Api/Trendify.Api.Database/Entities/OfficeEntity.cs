using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record OfficeEntity : BaseEntity
{
    public string Adress { get; set; } = string.Empty;

    //Data

    public List<TypesEntity> Types { get; set; } = new List<TypesEntity>();
    public List<UserEntity> Workers { get; set; } = new List<UserEntity>();

    //Lists
}