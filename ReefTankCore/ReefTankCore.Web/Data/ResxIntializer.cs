using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using ReefTankCore.Services.Context;

namespace ReefTankCore.Web.Data
{
    public static class ResxIntializer
    {
        public static void Initialze(ReefContext reefContext)
        {
            //using (ResXResourceWriter resx = new ResXResourceWriter(@".\CarResources.resx"))
            //{
            //    resx.AddResource("Title", "Classic American Cars");
            //    resx.AddResource("HeaderString1", "Make");
            //    resx.AddResource("HeaderString2", "Model");
            //    resx.AddResource("HeaderString3", "Year");
            //    resx.AddResource("HeaderString4", "Doors");
            //    resx.AddResource("HeaderString5", "Cylinders");
            //    resx.AddResource("Information", SystemIcons.Information);
            //    resx.AddResource("EarlyAuto1", car1);
            //    resx.AddResource("EarlyAuto2", car2);
            //}
        }
    }
}
