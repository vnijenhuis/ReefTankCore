using System;
using System.Collections.Generic;
using System.Text;

namespace ReefTankCore.Models.Base
{
    public class Media
    {
        public Guid Id { get; set; }

        public string Filename { get; set; }

        public string ContentType { get; set; }

        public byte[] Image { get; set; }

        public Guid? CreatureId { get; set; }
        public virtual Creature Creature { get; set; }
    }
}
