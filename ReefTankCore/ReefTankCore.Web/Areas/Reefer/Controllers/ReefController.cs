using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReefTankCore.Web.Areas.Reefer.Controllers
{
    [Area("Reefer"), Authorize(Policy = "ReefUser")]
    public class ReefController : Controller
    {
    }
}