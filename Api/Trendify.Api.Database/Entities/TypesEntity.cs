using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record TypesEntity : BaseEntity
{
    public int Type { get; set; }

    //Data

    public Guid OfficeId { get; set; }
}