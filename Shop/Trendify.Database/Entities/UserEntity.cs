using Trendify.EntityFramework.Configurations;

namespace Trendify.Database.Entities;

public sealed record UserEntity : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Login { get; set;} = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;

    public List<UserRolesEntity> Roles { get; set; } = new List<UserRolesEntity>();
    public List<ActionEntity> Actions { get; set; } = new List<ActionEntity>();
    public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    public List<CartEntity> Carts { get; set; } = new List<CartEntity>();
}