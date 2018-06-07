using System;
using System.Collections.Generic;
using System.Text;
using ReefTank.Models.Base;
using ReefTankCore.Core.Repositories;

namespace ReefTankCore.Models.Base
{
    public class CreatureReference : IAggregateRoot
    {
        public Guid Id { get; set; }

        public Guid ReferenceId { get; set; }
        public virtual Reference Reference { get; set; }

        public Guid CreatureId { get; set; }
        public virtual Creature Creature { get; set; }
    }
}
