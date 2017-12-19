using System.ComponentModel.DataAnnotations;

namespace ReefTankCore.Models.Enums
{
    public enum ReefCompatability
    {
        [Display(Name = "Unknown")]
        Unknown = 0,

        [Display(Name = "Is reef safe")]
        Always = 1,

        [Display(Name = "Is often reef safe")]
        Often = 2,

        [Display(Name = "Is reef safe with caution and proper care")]
        WithCaution = 3,

        [Display(Name = "Is reef safe if lucky")]
        WithLuck = 4,

        [Display(Name = "Is never reef safe")]
        Never = 5,
    }
}