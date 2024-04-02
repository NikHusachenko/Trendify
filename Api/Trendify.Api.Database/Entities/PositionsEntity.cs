using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record PositionsEntity : BaseEntity
{
    public string Position { get; set; } = string.Empty;

    //Data

    public Guid UserId { get; set; }


    //Foreig keys
}