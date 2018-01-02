using System.ComponentModel.DataAnnotations;

namespace ReefTankCore.Models.Enums
{
    public enum TagType
    {
        [Display(Name = "Information")]
        Information = 0,

        [Display(Name = "Caution")]
        Caution = 1,

        [Display(Name = "Warning")]
        Warning = 2,
    }
}