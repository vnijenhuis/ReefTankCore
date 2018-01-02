using System.Collections.Generic;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Web.Areas.Admin.Models.Creatures
{
    public class TagTypeViewModel
    {
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
    }
}