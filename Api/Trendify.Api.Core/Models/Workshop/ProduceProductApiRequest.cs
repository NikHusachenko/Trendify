namespace Trendify.Api.Core.Models.Workshop;

public sealed record ProduceProductApiRequest
{
    public Guid ProductId { get; set; }
}