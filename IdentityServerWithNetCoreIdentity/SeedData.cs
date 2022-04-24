using System.Security.Claims;

using IdentityModel;

using IdentityServerWithNetCoreIdentity.Data;
using IdentityServerWithNetCoreIdentity.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Serilog;

namespace IdentityServerWithNetCoreIdentity
{
    public class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var kelsey = userMgr.FindByNameAsync("kelsey").Result;
                if (kelsey == null)
                {
                    kelsey = new ApplicationUser
                    {
                        UserName = "kelsey",
                        Email = "KelseyGithtihu@email.com",
                        EmailConfirmed = true,
                    };
                    var result = userMgr.CreateAsync(kelsey, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(kelsey, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Kelsey Githtihu"),
                            new Claim(JwtClaimTypes.GivenName, "Kelsey"),
                            new Claim(JwtClaimTypes.FamilyName, "Githithu"),
                            new Claim(JwtClaimTypes.WebSite, "http://kelsey.com"),
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("kelsey created");
                }
                else
                {
                    Log.Debug("kelsey already exists");
                }

                var daniel = userMgr.FindByNameAsync("daniel").Result;
                if (daniel == null)
                {
                    daniel = new ApplicationUser
                    {
                        UserName = "daniel",
                        Email = "DanielGithithu@email.com",
                        EmailConfirmed = true
                    };
                    var result = userMgr.CreateAsync(daniel, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(daniel, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Daniel Githithu"),
                            new Claim(JwtClaimTypes.GivenName, "Daniel"),
                            new Claim(JwtClaimTypes.FamilyName, "Githithu"),
                            new Claim(JwtClaimTypes.WebSite, "http://daniel.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("daniel created");
                }
                else
                {
                    Log.Debug("daniel already exists");
                }
            }
        }
    }
}