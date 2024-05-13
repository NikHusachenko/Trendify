namespace Trendify.Api.Core.Models.Workshop;

public sealed record UpdateWorkshopNameApiRequest
{
    public string Name { get; set; } = string.Empty;
}