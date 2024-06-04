namespace Trendify.Api.Core.Models.Supply;

public sealed record NewSupplyApiRequest
{
    public Guid WorkshopId { get; set; }
    public List<MaterialRequest> Materials { get; set; } = new List<MaterialRequest>();
}

public sealed record MaterialRequest
{
    public Guid Id { get; set; }
    public int Count { get; set; }
}