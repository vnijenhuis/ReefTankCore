using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ReefTankCore.Models.Users
{
    public class UserToken : IdentityUserToken<Guid>
    {
    }
}
