namespace Trendify.Api.Database.Entities;

public sealed record ProductWorkshopsEntity : BaseEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }

    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }
}