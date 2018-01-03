using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Enums;

namespace ReefTankCore.Web.Areas.Admin.Models.Creatures
{
    public class CreatureDetailsModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Genus { get; set; }

        [Required]
        public string Species { get; set; }

        public string SubcategoryCommonName { get; set; }

        public string SubcategorySlug { get; set; }

        public string CategorySlug { get; set; }

        public string CommonName { get; set; }

        public string Origin { get; set; }

        public string Diet { get; set; }

        public double Length { get; set; }

        public double Volume { get; set; }

        public SpecialRequirements SpecialRequirements { get; set; }

        public List<SelectListItem> SpecialRequirementItems { get; set; }

        public ReefCompatability ReefCompatability { get; set; }

        public List<SelectListItem> ReefCompatabilityItems { get; set; }

        public Temperament Temperament { get; set; }

        public List<SelectListItem> TemperamentItems { get; set; }

        public Difficulty Difficulty { get; set; }

        public List<SelectListItem> DifficultyItems { get; set; }

        public string DifficultyDescription { get; set; }

        public string WaterMovement { get; set; }

        public string Lighting { get; set; }

        public string Fragmenting { get; set; }

        public double MinimumPh { get; set; }

        public double MaximumPh { get; set; }

        public int MinimumCalciumPpm { get; set; }

        public int MaximumCalciumPpm { get; set; }

        public double MinimumTemperature { get; set; }

        public double MaximumTemperature { get; set; }

        public string FileName { get; set; }

        [Required(ErrorMessage = "Please select a subcategory")]
        public Guid SubcategoryId { get; set; }

        public List<Subcategory> SubcategoryItems;
        
        public Guid[] TagList { get; set; }

        public List<TagTypeViewModel> TagItems { get; set; }
    }
}
