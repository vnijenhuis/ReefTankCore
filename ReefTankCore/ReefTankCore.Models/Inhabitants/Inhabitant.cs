using ReefTankCore.Models.Base;

namespace ReefTankCore.Models.Inhabitants
{
    public class Inhabitant : Creature
    {
        public virtual double Length { get; set; }

        public virtual double Volume { get; set; }

        public virtual SpecialRequirements SpecialRequirements { get; set; }

        public virtual ReefCompatability ReefCompatability { get; set; }

        public virtual Temperament Temperament { get; set; }
    }
}