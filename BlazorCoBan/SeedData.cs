using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCoBan
{
    //Seeding Data
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new ApplicationUser { UserName = "user1", Email = "user1@example.com" },
                    new ApplicationUser { UserName = "user2", Email = "user2@example.com" });
                context.SaveChanges();
            }
        }
    }

}
