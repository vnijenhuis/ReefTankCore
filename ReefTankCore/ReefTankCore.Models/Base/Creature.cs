using System;
using System.Collections.Generic;
using ReefTankCore.Models.Enums;

namespace ReefTankCore.Models.Base
{
    public class Creature
    {
        public Guid Id { get; set; }

        public string CommonName { get; set; }

        public string Description { get; set; }

        public string Genus { get; set; }

        public string Species { get; set; }

        public string Origin { get; set; }

        public string ScientificName
        {
            get
            {
                var fullName = Genus;
                fullName += " " + Species;
                return fullName;
            }
        }

        public string Diet { get; set; }

        public double Length { get; set; }

        public double Volume { get; set; }

        public SpecialRequirements SpecialRequirements { get; set; }

        public ReefCompatability ReefCompatability { get; set; }

        public Temperament Temperament { get; set; }

        public Difficulty Difficulty { get; set; }

        public string DifficultyDescription { get; set; }

        public string WaterMovement { get; set; }

        public string Lighting { get; set; }

        public string Fragmenting { get; set; }

        public double MinimumPh { get; set; }

        public double MaximumPh { get; set; }

        public string GetPhRange
        {
            get
            {
                var phValue = $"{MinimumPh} - {MaximumPh}";
                return phValue;
            }
        }

        public int MinimumCalciumPpm { get; set; }

        public int MaximumCalciumPpm { get; set; }

        public string GetCalciumRange
        {
            get
            {
                var phValue = $"{MinimumCalciumPpm} - {MaximumCalciumPpm}";
                return phValue;
            }
        }

        public double MinimumTemperature { get; set; }

        public double MaximumTemperature { get; set; }

        public string GetTemperatureRange
        {
            get
            {
                var phValue = $"{MinimumTemperature}°C - {MaximumTemperature}°C";
                return phValue;
            }
        }

        public virtual ICollection<CreatureTag> CreatureTags { get; set; }

        public virtual ICollection<CreatureReference> CreatureReferences { get; set; }

        public Guid? MediaId { get; set; }
        public virtual Media Media { get; set; }
        
        public Guid? SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
