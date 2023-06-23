using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCAuthenticationAPP.Areas.Identity.Data;
using MVCAuthenticationAPP.Data;

[assembly: HostingStartup(typeof(MVCAuthenticationAPP.Areas.Identity.IdentityHostingStartup))]
namespace MVCAuthenticationAPP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MVCAuthenticationAPPDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MVCAuthenticationAPP")));

                services.AddDefaultIdentity<MVCAuthenticationAPPUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false; //by default identity model required complex password
                    options.User.AllowedUserNameCharacters = string.Empty;

                }).AddEntityFrameworkStores<MVCAuthenticationAPPDbContext>();
            });
        }
    }
}