using System.ComponentModel.DataAnnotations;

namespace ReefTankCore.Models.Enums
{
    public enum Difficulty
    {
        [Display(Name = "Unknown")]
        Unknown = 0,

        [Display(Name = "Beginner")]
        Beginner = 1,

        [Display(Name = "Easy")]
        Easy = 2,

        [Display(Name = "Moderate")]
        Moderate = 3,

        [Display(Name = "Hard")]
        Hard = 4,

        [Display(Name = "Difficult")]
        Difficult = 5,
    }
}