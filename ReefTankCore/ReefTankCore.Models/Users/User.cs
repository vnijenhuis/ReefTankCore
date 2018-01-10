using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ReefTankCore.Core;

namespace ReefTankCore.Models.Users
{
    public class User : IdentityUser<Guid>
    {
        public string Firstname { get; set; }

        public string Preposition { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
