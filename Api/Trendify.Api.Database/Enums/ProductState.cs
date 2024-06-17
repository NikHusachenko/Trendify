using System.ComponentModel.DataAnnotations;

namespace Trendify.Api.Database.Enums;

public enum ItemCondition
{
    [Display(Name = "Unknown")]
    Unknown = 1,

    [Display(Name = "Defective")]
    Defective = 2,

    [Display(Name = "Ok")]
    Ok = 3,
}