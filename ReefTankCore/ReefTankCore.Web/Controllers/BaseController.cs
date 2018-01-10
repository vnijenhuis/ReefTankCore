using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.System.Notifications;

namespace ReefTankCore.Web.Controllers
{
    public class BaseController : Controller
    {
        public const string Key = "NotificationMessages";

        public void AddNotificationMessage(MessageViewModel message)
        {
            var messages = (IList<MessageViewModel>)TempData[Key] ?? new List<MessageViewModel>();

            messages.Add(message);
            TempData[Key] = messages;
        }
    }
}