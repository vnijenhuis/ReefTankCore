using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReefTankCore.Web.Areas.SystemOwner.Models
{
    public class UserViewModel
    { 
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}
