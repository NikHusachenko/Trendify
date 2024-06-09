using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record UserEntity : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public EmployeeType Type { get; set; }

    public Guid CredentialsId { get; set; }
    public CredentialsEntity Credentials { get; set; }

    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }

    public List<UserProductsEntity> Products { get; set; } = new List<UserProductsEntity>();
}