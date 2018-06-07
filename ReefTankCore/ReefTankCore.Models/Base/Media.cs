using System;
using System.Collections.Generic;
using System.Text;
using ReefTankCore.Core.Repositories;

namespace ReefTankCore.Models.Base
{
    public class Media : IAggregateRoot
    {
        public Guid Id { get; set; }

        public string Filename { get; set; }

        public string ContentType { get; set; }

        public string Url { get; set; }
    }
}
