using System;
using System.Collections.Generic;
using System.Text;
using ReefTank.Models.Base;

namespace ReefTankCore.Models.Base
{
    public class CreatureReference
    {
        public Guid Id { get; set; }

        public Guid ReferenceId { get; set; }
        public Reference Reference { get; set; }

        public Guid CreatureId { get; set; }
        public Creature Creature { get; set; }
    }
}
