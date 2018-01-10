using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ReefTankCore.Models.Users
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
    }
}
