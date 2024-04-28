namespace Trendify.Api.Database.Entities;

public sealed record MaterialWorkshopsEntity : BaseEntity
{
    public Guid MaterialId { get; set; }
    public MaterialEntity Material { get; set; }

    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }
}