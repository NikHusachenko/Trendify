using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record PositionsEntity : BaseEntity
{
    //Data

    public string Position { get; set; } = string.Empty;

  
    //Foreig keys

    public Guid UserId { get; set; }



}