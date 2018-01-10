using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReefTankCore.Models.Users;
using ReefTankCore.Services;
using ReefTankCore.Services.Context;
using ReefTankCore.Services.Email;
using ReefTankCore.Web.Data;

namespace ReefTankCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReefContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ReefTankCore.Web")));
            services.AddMvc();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IReefService, ReefService>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ReefContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;

                // SignIn settings
                options.SignIn.RequireConfirmedEmail = false;
            });

            //Add policy authorization
            services.AddAuthorization(options =>
            {
                //Only allows system owner to come in this area.
                options.AddPolicy("SystemOwner", policy =>
                {
                    policy.RequireRole("SystemOwner");
                });
                //Allows admin and system owner in this area.
                options.AddPolicy("Administrator", policy =>
                {
                    policy.RequireRole("SystemOwner", "Administrator");
                });
                //Allows reefuser, admin and systemowner in this area.
                options.AddPolicy("ReefUser", policy =>
                {
                    policy.RequireRole("SystemOwner", "Administrator", "ReefUser");
                });
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            Mapper.Initialize(configuration => configuration.AddProfile<AutoMapperProfile>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Admin_Category",
                    template: "Admin/Category/{action}/{slug?}");

                routes.MapRoute(
                    name: "Subcategory",
                    template: "Admin/Subcategory/{action}/{slug?}");

                routes.MapRoute(
                    name: "Creature",
                    template: "Admin/Creature/{action}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
