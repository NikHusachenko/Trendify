using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record TypesEntity : BaseEntity
{
    //Data
    public int Type { get; set; }


    //Foreig keys
    public Guid OfficeId { get; set; }
}