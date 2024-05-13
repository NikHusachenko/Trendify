namespace Trendify.Api.Core.Models.Workshop;

public sealed record UpdateWorkshopInfoApiRequest
{
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string LocalAddress { get; set; } = string.Empty;
}