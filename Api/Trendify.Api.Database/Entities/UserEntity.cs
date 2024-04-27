using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record UserEntity : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public EmployeeType Type { get; set; }
    
    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }
}