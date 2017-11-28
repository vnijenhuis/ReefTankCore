using System;
using System.Collections.Generic;
using System.Text;

namespace ReefTankCore.Models.Base
{
    public class CreatureTag
    {
        public int Id { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        public virtual Guid CreatureId { get; set; }
        public virtual Creature Creature { get; set; }
    }
}
