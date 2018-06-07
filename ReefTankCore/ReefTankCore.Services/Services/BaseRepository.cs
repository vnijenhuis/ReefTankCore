using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReefTankCore.Services.Context;

namespace ReefTankCore.Services.Services
{
    public class BaseRepository : IBaseRepository
    {
        //public DbContext Context { get; }
        public ReefContext Context { get; }

        public BaseRepository(ReefContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
