using System.ComponentModel.DataAnnotations;

namespace ReefTankCore.Models.Enums
{
    public enum SpecialRequirements
    {
        [Display(Name = "Unknown")]
        Unknown = 0,

        [Display(Name = "None")]
        None = 1,

        [Display(Name = "Requires special care")]
        SpecialCare = 2,

        [Display(Name = "Requires a specific aquarium.")]
        SpecialAquarium = 3,

        [Display(Name = "Requires experience, knowledge and special care.")]
        Experience = 4,

        [Display(Name = "Not suitable for home aquariums.")]
        NotSuitable = 5
    }
}