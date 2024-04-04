using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record UserEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string HashedPassword { get; set; }
    public EmployeeType Type { get; set; }
    
    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }
}