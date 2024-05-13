using Trendify.Api.Database.Enums;

namespace Trendify.Api.Core.Models.Workshop;

public sealed record NewWorkshopApiRequest
{
    public string Name { get; set; } = string.Empty;
    public WorkshopType Type { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string LocalAddress { get; set; } = string.Empty;
}