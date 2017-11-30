using ReefTankCore.Models.Base;

namespace ReefTankCore.Models.Corals
{
    public class Coral : Creature
    {
        public string Difficulty { get; set; }

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
                string phValue = $"{MinimumPh} - {MaximumPh}";
                return phValue;
            }
        }

        public int MinimumCalciumPpm { get; set; }

        public int MaximumCalciumPpm { get; set; }

        public string GetCalciumRange
        {
            get
            {
                string phValue = $"{MinimumCalciumPpm} - {MaximumCalciumPpm}";
                return phValue;
            }
        }

        public double MinimumTemperature { get; set; }

        public double MaximumTemperature { get; set; }

        public string GetTemperatureRange
        {
            get
            {
                string phValue = $"{MinimumTemperature}°C - {MaximumTemperature}°C";
                return phValue;
            }
        }
    }
}
