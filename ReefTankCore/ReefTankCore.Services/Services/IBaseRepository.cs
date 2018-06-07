using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReefTankCore.Services.Context;

namespace ReefTankCore.Services.Services
{
    public interface IBaseRepository : IDisposable
    {
        ReefContext Context { get; }
        void Commit();
    }
}
