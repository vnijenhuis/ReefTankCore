using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReefTankCore.Web.Areas.SystemOwner.Models
{
    public class UserViewModel
    { 
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string EmailAddres { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}
