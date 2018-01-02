using System;
using System.Collections.Generic;
using System.Text;

namespace ReefTankCore.Models.Users
{
    public class UserRole
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsAssignable { get; set; }
    }
}
