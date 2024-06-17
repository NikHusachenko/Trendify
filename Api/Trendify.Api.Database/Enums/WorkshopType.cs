using System.ComponentModel.DataAnnotations;

namespace Trendify.Api.Database.Enums;

public enum WorkshopType
{
    /*[Display(Name = "Office")]
    Office = 1,*/

    [Display(Name = "Warehouse")]
    Warehouse = 1,

    [Display(Name = "Cutting")]
    Cutting = 2,

    [Display(Name = "Experimental")]
    Experimental = 3,

    [Display(Name = "Sewing")]
    Sewing = 4,
}