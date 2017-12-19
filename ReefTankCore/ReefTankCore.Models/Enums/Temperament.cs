using System.ComponentModel.DataAnnotations;

namespace ReefTankCore.Models.Enums
{
    public enum Temperament
    {
        [Display(Name = "Unknown")]
        Unknown = 0,

        [Display(Name = "Docile")]
        Docile = 1,

        [Display(Name = "Peaceful")]
        Peaceful = 2,

        [Display(Name = "Semi-aggressive")]
        SemiAgressive = 3,

        [Display(Name = "Aggressive")]
        Agressive = 4,
    }
}