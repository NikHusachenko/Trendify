namespace Trendify.Api.Core.Models.Material;

public sealed record RegisterMaterialApiRequest
{
    public string Name { get; set; } = string.Empty;
}