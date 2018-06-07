using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Users;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.SystemOwner.Models;

namespace ReefTankCore.Web.Areas.SystemOwner.Controllers
{
    public class UserController : SystemController
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();

            var vm = new UserOverviewViewModel()
            {
                Users = Mapper.Map<IEnumerable<User>, IList<UserViewModel>>(users),
            };

            return View(vm);
        }
    }
}