using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReefTankCore.Web.Areas.SystemOwner.Models
{
    public class UserOverviewViewModel
    {
        public IList<UserViewModel> Users { get; set; }
    }
}
