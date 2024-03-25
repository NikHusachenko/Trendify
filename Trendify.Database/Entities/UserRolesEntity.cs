namespace Trendify.Database.Entities;

public sealed record UserRolesEntity
{
    public Guid RoleId { get; set; }
    public RoleEntity Role { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}