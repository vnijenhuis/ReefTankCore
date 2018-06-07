﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "Administrator")]
    public class AdminController : Controller
    {
    }
}