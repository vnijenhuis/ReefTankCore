using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ReefTankCore.Core.Repositories;

namespace ReefTankCore.Models.Base
{
    public class CreatureTag : IAggregateRoot
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public Guid CreatureId { get; set; }
        public virtual Creature Creature { get; set; }
    }
}
