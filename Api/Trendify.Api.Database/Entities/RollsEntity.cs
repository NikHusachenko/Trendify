﻿using Trendify.Api.Database.Entities;

namespace Trendify.Api.Database.Entities;

public sealed record RollsEntity : BaseEntity
{    //Data

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Count {  get; set; }
    public string Color { get; set; } = string.Empty;
    public int RAL { get; set; }

    //Foreing keys

    public Guid PreparatoryWorkshopId { get; set; }


}