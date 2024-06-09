namespace Trendify.Api.Core.Models.Authentication;

public sealed record SignUpApiRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid WorkshopId { get; set; }
}