using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Enums;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Areas.Admin.Models.Creatures;

namespace ReefTankCore.Web.Models
{
    public class CreatureViewModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Genus { get; set; }

        public string Species { get; set; }

        public string SubcategoryCommonName { get; set; }

        public string CategoryName { get; set; }

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

        public Guid SubcategoryId { get; set; }

        public List<Subcategory> SubcategoryItems { get; set; }

        public Guid[] TagList { get; set; }

        public List<TagTypeViewModel> TagItems { get; set; }
        public Guid CategoryId { get; set; }
    }
}
