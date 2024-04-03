using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
namespace Trendify.Api.Database.Entities;

public sealed record PositionEntity : BaseEntity
{
    public string Position { get; set; } = string.Empty;
  

    public Guid UserId { get; set; }

    public UserEntity User { get; set; }

}