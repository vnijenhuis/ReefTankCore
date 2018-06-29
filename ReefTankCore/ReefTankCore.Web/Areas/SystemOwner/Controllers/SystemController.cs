using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReefTankCore.Web.Areas.SystemOwner.Controllers
{
    [Area("SystemOwner"), Authorize(Policy = "SystemOwner")]
    public class SystemController : Controller
    {
    }
}