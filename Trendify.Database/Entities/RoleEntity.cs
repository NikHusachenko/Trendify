namespace Trendify.Database.Entities;

public sealed record RoleEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<UserRolesEntity> Users { get; set; } = new List<UserRolesEntity>();
}